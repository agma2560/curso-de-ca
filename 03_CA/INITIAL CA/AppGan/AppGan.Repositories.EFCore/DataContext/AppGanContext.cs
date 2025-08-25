using AppGan.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;

namespace AppGan.Repositories.EFCore.DataContext
{
    public class AppGanContext : DbContext
    {
        public AppGanContext(DbContextOptions<AppGanContext> options) : base(options) 
        { 
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // Características de las Entidades
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                 .Property(c => c.Name).IsRequired()
                 .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name).IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(o => o.Id).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress).IsRequired()
                .HasMaxLength(100);

            // Poblar la tabla Products
            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Name = "PEPITO LOPEZ" },
                new Product { Id = 2, Name = "FRANCISCO GUEVARA" },
                new Product { Id = 1, Name = "MANUEL PEREIRA" }
                );

            modelBuilder.Entity<Animal>()
                .Property(e => e.Name).IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Animal>()
                .Property(e => e.Number).HasMaxLength(15);
            modelBuilder.Entity<Animal>()
                .Property(e => e.Color).IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Animal>()
                .Property(e => e.race).HasMaxLength(20);
            modelBuilder.Entity<Animal>()
                .Property(e => e.Sex).HasMaxLength(10);
            modelBuilder.Entity<Animal>()
                .Property(e => e.Status).IsRequired();
        }

    }
}
