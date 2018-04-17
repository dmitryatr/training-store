using Site.Domain.Entities;
using System.Data.Entity;
using MySql.Data.Entity;

namespace Site.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Vinyl> products { get; set; }
    }
}
