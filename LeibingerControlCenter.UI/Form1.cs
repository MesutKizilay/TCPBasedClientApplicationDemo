using LeibingerControlCenter.Business.Abstract;
using LeibingerControlCenter.Business.Helpers;
using LeibingerControlCenter.Entities.Concrete;
using File = LeibingerControlCenter.Entities.Concrete.File;

namespace LeibingerControlCenterUI
{
    public partial class Form1 : Form
    {
        private IClientService _clientService;
        private IFileManager _fileManager;
        private CancellationTokenSource _cancellationTokenSource;

        public Form1(IClientService clientService, IFileManager fileManager)
        {
            InitializeComponent();

            _cancellationTokenSource = new CancellationTokenSource();
            _clientService = clientService;
            _fileManager = fileManager;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            cmbIpAddress.DataSource = await _clientService.GetClients();
            cmbIpAddress.DisplayMember = "Ip";
            cmbIpAddress.ValueMember = "Port";

            var port = txtPort.Text = cmbIpAddress.SelectedValue?.ToString();
            var ipAddress = cmbIpAddress.SelectedItem as Client;

            await _clientService.ConnectToServer(ipAddress.Ip, Convert.ToInt32(port));
        }

        private async Task<List<string>> ConversationToPrinter(string requestType)
        {
            string? response = "";

            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                var request = RequestHelper.BuildRequest(requestType);
                await _clientService.SendDataToServer(request);

                response = await _clientService.GetDataFromServer();

                if (string.IsNullOrEmpty(response))
                {
                    MessageBox.Show("Yaz�c�dan veri al�namad�.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<string>();
                }

                if (response.StartsWith("^0*"))
                {
                    return new List<string>() { response };
                    //return response.ToList();
                }

                return RequestHelper.ParseResponse(response);
            }
            return new List<string>();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbIpAddress.Text) || string.IsNullOrEmpty(txtPort.Text))
            {
                MessageBox.Show("L�tfen IP adresi ve portu giriniz.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var result = await _clientService.ConnectToServer(cmbIpAddress.Text, int.Parse(txtPort.Text));
            _cancellationTokenSource = new CancellationTokenSource();

            if (result.Success)
            {
                MessageBox.Show(result.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            try
            {
                //_tcpClient.ConnectToServer();

                _clientService.SendDataToServer(txtData.Text);
                //_tcpClient.DisconnectFromServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olu�tu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        private async Task ListenToServer()
        {
            try
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    // UI Thread'de TextBox'a yaz
                    //Invoke(new Action(() =>
                    //{
                    txtData.AppendText(await _clientService.GetDataFromServer() + Environment.NewLine);
                    //}));

                    //await Task.Delay(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dinleme hatas�: " + ex.Message);
            }
        }

        private async void btnPrinterStatus_Click(object sender, EventArgs e)
        {
            var response = await ConversationToPrinter("?RS");

            if (response.Any())
            {
                PrinterStatus printerStatus = new PrinterStatus
                {
                    NozzleState = (NozzleState)int.Parse(response[0]),
                    MachineState = (MachineState)int.Parse(response[1]),
                    ErrorNumber = int.Parse(response[2]),
                    HeadCoverClosed = response[3] == "1",
                    CurrentSpeed = float.Parse(response[4]),
                    JobChangeFlag = response[5] == "1"
                };

                lblNozzleStatus.Text = printerStatus.NozzleState switch
                {
                    NozzleState.Invalid => "Ge�ersiz",
                    NozzleState.Opens => "A��l�yor",
                    NozzleState.Open => "A��k",
                    NozzleState.Closes => "Kapan�yor",
                    NozzleState.Closed => "Kapal�",
                    NozzleState.InBetween => "Arada",
                    _ => "Bilinmiyor"
                };

                lblMachineStatus.Text = printerStatus.MachineState switch
                {
                    MachineState.Standby => "Bekleme",
                    MachineState.Initialization => "Ba�latma",
                    MachineState.ServicePanel => "Servis Paneli",
                    MachineState.ReadyForAction => "Eyleme Haz�r",
                    MachineState.ReadyForPrint => "Bask�ya Haz�r",
                    MachineState.Printing => "Bask� Yap�l�yor",
                    _ => "Bilinmiyor"
                };

                string errorNumberBinary = "";
                if (printerStatus.ErrorNumber != 0)
                {
                    errorNumberBinary = RequestHelper.ConvertDecimalToBinary(printerStatus.ErrorNumber);
                    printerStatus.ErrorInfo = RequestHelper.ParseErrorBits(errorNumberBinary);
                    panel1.Visible = true;
                }

                lblErrorStatus.Text = printerStatus.ErrorNumber switch
                {
                    0 => "Hata Yok",
                    //_ => $"Hata Kodu: {printerStatus.ErrorNumber}"
                    _ => "Hata Var"
                };

                txtDisplayType.Text = printerStatus.ErrorInfo?.Display switch
                {
                    DisplayType.ErrorWindow => "Hata",
                    DisplayType.WarningWindow => "Uyar�",
                    DisplayType.MessageWindow => "Mesaj",
                    _ => "Bilinmiyor"
                };

                txtSignalTone.Text = printerStatus.ErrorInfo?.Tone switch
                {
                    SignalTone.Permanent => "S�rekli",
                    SignalTone.OneTime => "Tek Seferlik",
                    SignalTone.None => "Ses Yok",
                    _ => "Bilinmiyor"
                };

                txtShutdownBehavior.Text = printerStatus.ErrorInfo?.Shutdown switch
                {
                    ShutdownBehavior.ShutdownAfter30Min => "Onay Gelmez �se 30 Dakika Sonra Kapanacak",
                    ShutdownBehavior.NoShutdown => "Kapatma Yok",
                    _ => "Bilinmiyor"
                };

                txtErrorSource.Text = printerStatus.ErrorInfo?.Source switch
                {
                    ErrorSource.FepCPU => "Aray�z Hatas�",
                    ErrorSource.RipCPU => "Yazd�rma veya Hidrolik Sistem Hatas�",
                    ErrorSource.SdcCPU => "Dots ve Yaz�c� Kafa Hatas�",
                    _ => "Bilinmiyor"
                };

                lblHeadCover.Text = !printerStatus.HeadCoverClosed ? "Kapak Kapal�" : "Kapak A��k";

                lblCurrentSpeed.Text = printerStatus.CurrentSpeed.ToString("F2") + " m/m";

                lblJobChange.Text = printerStatus.JobChangeFlag ? "�� De�i�ikli�i Var" : "�� De�i�ikli�i Yok";
            }
        }

        private void cmbIpAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            var port = cmbIpAddress.SelectedValue?.ToString();

            txtPort.Text = port ?? string.Empty;
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            await _cancellationTokenSource.CancelAsync();
            _clientService.DisconnectFromServer();
        }

        private async void btnDirectoryInfo_Click(object sender, EventArgs e)
        {
            var response = await ConversationToPrinter("$RDFFSDISK\\Jobs\\*");

            if (response.Any())
            {
                File file = new File()
                {
                    NoOfEntries = int.Parse(response[1]),
                    FileNames = response.Skip(2).ToList()
                };

                var listViewITems = file.FileNames.Select(f => new ListViewItem(f) { }).ToArray();

                lvJobs.Items.Clear();
                lvJobs.Items.AddRange(listViewITems);


                //listView1.Columns.Add("Dosya Ad�");
            }
        }

        private async void btnJobLoad_Click(object sender, EventArgs e)
        {
            if (lvJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("L�tfen bir dosya se�iniz.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedFile = lvJobs.SelectedItems[0].Text; // Se�ilen ilk itemin Text'i

            var requestType = $"=JLFFSDISK\\JOBS\\{selectedFile}";

            var response = await ConversationToPrinter(requestType);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (lvJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("L�tfen bir dosya se�iniz.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var response = await ConversationToPrinter("?JB");

            await _fileManager.DownloadFile(lvJobs.SelectedItems[0].Text, response[0]);
        }

        private async void btnLoadFile_Click(object sender, EventArgs e)
       {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Bir dosya se�iniz";
                openFileDialog.Filter = "Job ve Log Dosyalar� (*.job, *.log)|*.job;*.log|T�m Dosyalar (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    //DialogResult result = MessageBox.Show(
                    //    "Dosyay� yaz�c�ya y�klemek istiyor musunuz?",
                    //    "Onay",
                    //    MessageBoxButtons.YesNo,
                    //    MessageBoxIcon.Question
                    //);

                    //if (result == DialogResult.Yes)
                    {

                        string fileName = Path.GetFileName(selectedFilePath);
                        string message = await System.IO.File.ReadAllTextAsync(selectedFilePath);

                        await _clientService.SendDataToServer(message);
                    }
                }
            }
        }
    }
}