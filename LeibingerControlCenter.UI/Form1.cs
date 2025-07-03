using LeibingerControlCenter.Business.Abstract;
using LeibingerControlCenter.Business.Helpers;
using LeibingerControlCenter.Entities.Concrete;
using LeibingerControlCenterUI.Entities;

namespace LeibingerControlCenterUI
{
    public partial class Form1 : Form
    {
        private IClientService _clientService;
        private TCPClient _TCPClient;

        private CancellationTokenSource _cancellationTokenSource;

        public Form1(IClientService clientService)
        {
            InitializeComponent();

            _cancellationTokenSource = new CancellationTokenSource();
            _clientService = clientService;
            _TCPClient = new TCPClient();
        }

        private async Task<List<string>> ConversationToPrinter(string requestType)
        {
            string? response = "";

            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                var request = RequestHelper.BuildRequest(requestType);
                await _TCPClient.SendDataToServer(request);

                response = await _TCPClient.GetDataFromServer();

                if (string.IsNullOrEmpty(response))
                {
                    MessageBox.Show("Yazýcýdan veri alýnamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<string>();
                }

                return RequestHelper.ParseResponse(response);
            }
            return new List<string>();
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (btnConnect.Text == "Baðlan")
            //    {
            //        _tcpClient.ConnectToServer();
            //        btnConnect.Text = "Baðlantýyý Kes";
            //    }
            //    else
            //    {
            //        _tcpClient.DisconnectFromServer();
            //        btnConnect.Text = "Baðlan";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Bir hata oluþtu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //throw;
            //}
            _cancellationTokenSource.Cancel();
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
                MessageBox.Show("Bir hata oluþtu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Dinleme hatasý: " + ex.Message);
            }
        }

        private async void btnPrinterStatus_Click(object sender, EventArgs e)
        {
            var response = await ConversationToPrinter("?RS");

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
                NozzleState.Invalid => "Geçersiz",
                NozzleState.Opens => "Açýlýyor",
                NozzleState.Open => "Açýk",
                NozzleState.Closes => "Kapanýyor",
                NozzleState.Closed => "Kapalý",
                NozzleState.InBetween => "Arada",
                _ => "Bilinmiyor"
            };

            lblMachineStatus.Text = printerStatus.MachineState switch
            {
                MachineState.Standby => "Bekleme",
                MachineState.Initialization => "Baþlatma",
                MachineState.ServicePanel => "Servis Paneli",
                MachineState.ReadyForAction => "Eyleme Hazýr",
                MachineState.ReadyForPrint => "Baskýya Hazýr",
                MachineState.Printing => "Baský Yapýlýyor",
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
                DisplayType.WarningWindow => "Uyarý",
                DisplayType.MessageWindow => "Mesaj",
                _ => "Bilinmiyor"
            };

            txtSignalTone.Text = printerStatus.ErrorInfo?.Tone switch
            {
                SignalTone.Permanent => "Sürekli",
                SignalTone.OneTime => "Tek Seferlik",
                SignalTone.None => "Ses Yok",
                _ => "Bilinmiyor"
            };

            txtShutdownBehavior.Text= printerStatus.ErrorInfo?.Shutdown switch
            {
                ShutdownBehavior.ShutdownAfter30Min => "Onay Gelmez Ýse 30 Dakika Sonra Kapanacak",
                ShutdownBehavior.NoShutdown => "Kapatma Yok",
                _ => "Bilinmiyor"
            };

            txtErrorSource.Text=printerStatus.ErrorInfo?.Source switch
            {
                ErrorSource.FepCPU => "Arayüz Hatasý",
                ErrorSource.RipCPU => "Yazdýrma veya Hidrolik Sistem Hatasý",
                ErrorSource.SdcCPU => "Dots ve Yazýcý Kafa Hatasý",
                _ => "Bilinmiyor"
            };

            lblHeadCover.Text = !printerStatus.HeadCoverClosed ? "Kapak Kapalý" : "Kapak Açýk";

            lblCurrentSpeed.Text = printerStatus.CurrentSpeed.ToString("F2") + " m/m";

            lblJobChange.Text = printerStatus.JobChangeFlag ? "Ýþ Deðiþikliði Var" : "Ýþ Deðiþikliði Yok";
        }
    }
}