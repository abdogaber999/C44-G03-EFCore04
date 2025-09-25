using InheritanceMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace InheritanceMappingDemo.DatabaseContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<CreditCardPayment> CreditCardPayments { get; set; }
        public DbSet<CashPayment> CashPayments { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Electronics> Electronics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ABDELRAHMAN;Database=Vehicles;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPH Mapping (vehicle) 
            modelBuilder.Entity<Vehicle>()
                .HasDiscriminator<string>("VehicleType")
                .HasValue<Vehicle>("Vehicle")
                .HasValue<Car>("Car")
                .HasValue<Bus>("Bus");

            // TPT Mapping (payment)
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<CreditCardPayment>().ToTable("CreditCardPayments");
            modelBuilder.Entity<CashPayment>().ToTable("CashPayments");

            // TPC Mapping (Products → No Base Table)
            modelBuilder.Entity<Book>().ToTable("Books").UseTpcMappingStrategy();
            modelBuilder.Entity<Electronics>().ToTable("Electronics").UseTpcMappingStrategy();

            base.OnModelCreating(modelBuilder);
        }
    }
}
