using LeibingerControlCenter.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.Business.Concrete
{
    public class ClientManager : IClientService
    {
        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private string _ip;
        private int _port;

        public ClientManager(TcpClient client)
        {
            _tcpClient = client;
        }

        public async Task ConnectToServer(string ip = "127.0.0.1", int port = 80)
        {
            _ip = ip;
            _port = port;
            //_tcpClient = new TcpClient();
            await _tcpClient.ConnectAsync(_ip, _port);

            //Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Socket.Connect("127.0.0.1", 80);
            //Socket.Send(Encoding.UTF8.GetBytes("Merhaba"));


            //Client.SendBufferSize = BufferSize;
            //Client.ReceiveBufferSize = BufferSize;
        }

        public void DisconnectFromServer()
        {
            if (_tcpClient != null)
            {
                _tcpClient?.Close();
                _tcpClient?.Dispose();
                _stream?.Dispose();
                _stream?.Close();
                _tcpClient = null;
            }
        }

        public async Task SendDataToServer(string message)
        {
            try
            {
                await ConnectToServer();
                _stream = _tcpClient.GetStream();

                byte[] data = Encoding.GetEncoding("ISO-8859-9").GetBytes(message);
                await _stream.WriteAsync(data, 0, data.Length);
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
                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
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
                _stream.Dispose();
                DisconnectFromServer();
            }
        }
    }
}