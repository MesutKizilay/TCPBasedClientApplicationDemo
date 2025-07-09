using Microsoft.EntityFrameworkCore;
using LeibingerControlCenter.Entities.Concrete;

namespace LeibingerControlCenter.DataAccess.Concrete
{
    public class LeibingerContext : DbContext
    {
        public DbSet<Client> CLIENTS { get; set; }

        public LeibingerContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}