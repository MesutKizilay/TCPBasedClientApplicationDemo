using Core.Utilities.Results;
using LeibingerControlCenter.Business.Abstract;
using LeibingerControlCenter.DataAccess.Abstract;
using LeibingerControlCenter.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.Business.Concrete
{
    public class ClientManager : IClientService
    {
        private readonly IClientDal _clientDal;
        private TcpClient _tcpClient;
        private NetworkStream _stream;
        //private string _ip;
        //private int _port;

        public ClientManager(TcpClient client, IClientDal clientDal)
        {
            _tcpClient = client;
            _clientDal = clientDal;
        }

        //public async Task<IResult> ConnectToServer(string ip, int port)
        //{
        //    //_ip = ip;
        //    //_port = port;

        //    if (!_tcpClient.Connected)
        //    {
        //        await _tcpClient.ConnectAsync(ip, port);
        //    }

        //    return new SuccessResult("Bağlantı başarılı.");


        //    //Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    //Socket.Connect("127.0.0.1", 80);
        //    //Socket.Send(Encoding.UTF8.GetBytes("Merhaba"));


        //    //Client.SendBufferSize = BufferSize;
        //    //Client.ReceiveBufferSize = BufferSize;
        //}

        public async Task<IResult> ConnectToServer(string ip, int port)
        {

            // Eğer client zaten bağlıysa, önce bağlantıyı kopar
            if (_tcpClient.Connected)
            {
                var currentEndpoint = _tcpClient.Client.RemoteEndPoint as IPEndPoint;

                // Aynı IP/Port değilse bağlantıyı kopart ve yenisini oluştur
                if (currentEndpoint == null || currentEndpoint.Address.ToString() != ip || currentEndpoint.Port != port)
                {
                    _tcpClient.Close();
                    _tcpClient.Dispose();
                    _tcpClient = new TcpClient();
                }
                else
                {
                    return new SuccessResult("Zaten bu IP ve port ile bağlantı var.");
                }
            }

            if (_tcpClient.Client == null)
            {
                _tcpClient = new TcpClient();
            }

            // Yeni bağlantı denemesi
            await _tcpClient.ConnectAsync(ip, port);

            return new SuccessResult("Yeni bağlantı başarılı.");
        }

        public void DisconnectFromServer()
        {
            if (_tcpClient != null)
            {
                _tcpClient?.Close();
                _tcpClient?.Dispose();
                _stream?.Dispose();
                _stream?.Close();
                //_tcpClient = null;
            }
        }

        public async Task SendDataToServer(string message)
        {
            try
            {
                //await ConnectToServer();
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
                byte[] buffer = new byte[1024 * 5];
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
                //DisconnectFromServer();
            }
        }

        public async Task<List<Client>> GetClients()
        {
            return await _clientDal.GetClients();
        }
    }
}