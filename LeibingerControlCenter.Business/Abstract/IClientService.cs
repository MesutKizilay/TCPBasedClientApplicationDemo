using Core.Utilities.Results;
using LeibingerControlCenter.Entities.Concrete;

namespace LeibingerControlCenter.Business.Abstract
{
    public interface IClientService
    {
        public Task<IResult> ConnectToServer(string ip,int port);
        public void DisconnectFromServer();
        public Task SendDataToServer(string message);
        public Task<string?> GetDataFromServer();
        public Task<List<Client>> GetClients();
    }
}