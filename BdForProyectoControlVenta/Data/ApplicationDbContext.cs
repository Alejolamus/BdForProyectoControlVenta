using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using BdForProyectoControlVenta.Models; 

namespace BdForProyectoControlVenta.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<UnidadesVendidas> UnidadesVendidas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}
