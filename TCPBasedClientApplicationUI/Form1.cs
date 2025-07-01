

using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using TCPBasedClientApplicationUI.Entities;

namespace TCPBasedClientApplicationUI
{
    public partial class Form1 : Form
    {
        private TCPClient _tcpClient;
        private CancellationTokenSource _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _tcpClient = new TCPClient();

            //await ListenToServer();

            ConversationToServer();
        }

        private async void ConversationToServer()
        {
            string? message = "";

            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                _tcpClient.SendDataToServer("STATUS\n");

                message = await _tcpClient.GetDataFromServer();

                var printerDTO = ParseStatus(message);

                lblPrinterStatus.Text = printerDTO.PrinterStatus switch
                {
                    PrinterStatus.Open => "Yazýcý Açýk",
                    PrinterStatus.Close => "Yazýcý Kapalý",
                    PrinterStatus.Busy => "Yazýcý Meþgul",
                    _ => "Yazýcý Bilgisi Alýnamýyor"
                };

                lblErrorStatus.Text = printerDTO.ErrorStatus switch
                {
                    ErrorStatus.Error => "Hata Var",
                    ErrorStatus.NoError => "Hata Yok",
                    _ => "Hata Bilgisi Alýnamýyor"

                };

                lblNoozleStatus.Text = printerDTO.NozzleStatus switch
                {
                    NozzleStatus.Open => "Nozzle Açýk",
                    NozzleStatus.Close => "Nozzle Kapalý",
                    _ => "Nozzle Bilgisi Alýnamýyor"
                };
            }
        }

        public PrinterDTO ParseStatus(string message)
        {
            // STATUS= kýsmýný çýkar
            var indexOfEqual = message.IndexOf("=");
            //var y = message.Length - 1;

            string payload = message.Substring(message.IndexOf("=") + 1, message.Length - 1 - indexOfEqual);


            string[] parts = payload.Split('\t', StringSplitOptions.RemoveEmptyEntries);

            //if (parts.Length < 3)
            //    MessageBox.Show("Bir hata oluþtu: Eksik parametre sayýsý", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            int yazici = parts.Length > 0 ? int.Parse(parts[1]) : '!';
            int hata = parts.Length > 1 ? int.Parse(parts[1]) : '!';
            int nozzle = parts.Length > 2 ? int.Parse(parts[2]) : '!';

            return new PrinterDTO
            {
                PrinterStatus = (PrinterStatus)yazici,
                ErrorStatus = (ErrorStatus)hata,
                NozzleStatus = (NozzleStatus)nozzle
            };
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

                _tcpClient.SendDataToServer(txtData.Text);
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
                    txtData.AppendText(await _tcpClient.GetDataFromServer() + Environment.NewLine);
                    //}));

                    //await Task.Delay(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dinleme hatasý: " + ex.Message);
            }
        }
    }
}