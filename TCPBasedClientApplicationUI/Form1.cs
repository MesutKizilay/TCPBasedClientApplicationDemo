

using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _tcpClient = new TCPClient();

            ServeriDinleAsync();
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

        private void ServeriDinleAsync()
        {
            try
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    // UI Thread'de TextBox'a yaz
                    //Invoke(new Action(() =>
                    //{
                    txtData.AppendText(_tcpClient.GetDataFromServer() + Environment.NewLine);
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