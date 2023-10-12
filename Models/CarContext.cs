using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using System.Xml.Linq;

namespace Cars.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions options) : base(options)
        {
        }

        public CarContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = new MySqlConnection(new MySqlConnectionStringBuilder
                {
                    Server = "192.168.50.28",
                    UserID = "root",
                    Password = "password",
                    Database = "carsdb",
                    SslMode = MySqlSslMode.None
                }.ConnectionString);
                optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
            }
        }

        public DbSet<Car> Cars { get; set; }
    }
}
