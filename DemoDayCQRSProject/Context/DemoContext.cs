using DemoDayCQRSProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.Context
{
    public class DemoContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial Catalog=RentACarCQRSDB;Integrated Security=true;Encrypt=True;TrustServerCertificate=True;");

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
  

    }
