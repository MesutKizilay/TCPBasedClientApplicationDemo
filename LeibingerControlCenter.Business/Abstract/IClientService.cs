using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.Business.Abstract
{
    public interface IClientService
    {
        public Task ConnectToServer(string ip,int port);
        public void DisconnectFromServer();
        public Task SendDataToServer(string message);
        public Task<string?> GetDataFromServer();
    }
}