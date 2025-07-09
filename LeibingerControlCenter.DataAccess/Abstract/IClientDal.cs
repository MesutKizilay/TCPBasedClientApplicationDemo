using LeibingerControlCenter.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.DataAccess.Abstract
{
    public interface IClientDal
    {
        Task<List<Client>> GetClients();
    }
}