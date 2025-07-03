using System.Net.Sockets;
using System.Text;

namespace LeibingerControlCenterUI.Entities
{
    public class TCPClient
    {
        private TcpClient Client;
        private Socket Socket;
        //public byte StartByte;
        //public bool IsConnectedToServer = false;
        private string IP;
        private int Port;
        private NetworkStream Stream;

        //public TCPClient(int port = 3000, string ip = "192.168.111.50")
        public TCPClient(int port = 80, string ip = "127.0.0.1")
        {
            Port = port;
            IP = ip;
        }

        private async Task ConnectToServer()
        {
            Client = new TcpClient();
            await Client.ConnectAsync(IP, Port);

            //Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Socket.Connect("127.0.0.1", 80);
            //Socket.Send(Encoding.UTF8.GetBytes("Merhaba"));


            //Client.SendBufferSize = BufferSize;
            //Client.ReceiveBufferSize = BufferSize;
        }

        private void DisconnectFromServer()
        {
            if (Client != null)
            {
                Client?.Close();
                Client?.Dispose();
                Stream?.Dispose();
                Stream?.Close();
                Client = null;
            }
        }

        public async Task SendDataToServer(string message)
        {
            try
            {
                await ConnectToServer();
                Stream = Client.GetStream();

                byte[] data = Encoding.GetEncoding("ISO-8859-9").GetBytes(message);
                await Stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                throw;
            }
            //finally
            //{
            //    //Stream.Dispose();
            //    /*DisconnectFromServer();*/
            //}
        }

        public async Task<string?> GetDataFromServer()
        {
            //ConnectToServer();
            //Stream = Client.GetStream();

            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await Stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string mesaj = Encoding.GetEncoding("ISO-8859-9").GetString(buffer, 0, bytesRead);

                    // UI Thread'de TextBox'a yaz
                    //Invoke(new Action(() =>
                    //{
                    return mesaj;
                    //}));
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Stream.Dispose();
                DisconnectFromServer();
            }
        }
    }
}