using Microsoft.EntityFrameworkCore;

namespace LønTransportberegner.Models.Domæne
{
    public class ConnectDbContext : DbContext
    {
        

        public ConnectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CityModel> Cities { get; set; }
    }
}
