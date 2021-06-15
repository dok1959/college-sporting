using CollegeSporting.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSporting.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedCountries.CreateSeedCountries(modelBuilder);
            SeedProducts.CreateSeedProducts(modelBuilder);
            SeedTechnicians.CreateSeedTechnicians(modelBuilder);
            SeedCustomers.CreateSeedCustomers(modelBuilder);
            SeedIncidents.CreateSeedIncidents(modelBuilder);
            SeedRegistrations.CreateSeedRegistrations(modelBuilder);
        }
    }
}
