using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Teclado mecánico", Precio = 250.00m, Stock = 15 },
                new Producto { Id = 2, Nombre = "Mouse inalámbrico", Precio = 120.50m, Stock = 30 },
                new Producto { Id = 3, Nombre = "Monitor 24 pulgadas", Precio = 950.00m, Stock = 8 }
            );
        }
    }
}