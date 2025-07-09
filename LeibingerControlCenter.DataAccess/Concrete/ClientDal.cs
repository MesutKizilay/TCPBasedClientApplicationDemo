using LeibingerControlCenter.DataAccess.Abstract;
using LeibingerControlCenter.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.DataAccess.Concrete
{
    public class ClientDal : IClientDal
    {
        private readonly LeibingerContext _context;

        public ClientDal(LeibingerContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetClients()
        {
            // Fix: Ensure the correct usage of FromSqlRaw and add the required namespace for it.
            return await _context.CLIENTS.FromSqlRaw("EXEC SP_GETALLCLIENTS").ToListAsync();
        }
    }
}