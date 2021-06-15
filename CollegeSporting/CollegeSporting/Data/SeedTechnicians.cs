using CollegeSporting.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSporting.Data
{
    public static class SeedTechnicians
    {
        public static void CreateSeedTechnicians(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Technician>().HasData
                (
                    new Technician { Id = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", Phone = "8005550443"},
                    new Technician { Id = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", Phone = "8005550449" },
                    new Technician { Id = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", Phone = "8005550459" },
                    new Technician { Id = 4, Name = "Gunter Wendt", Email = "gunter@sportsprosoftware.com", Phone = "8005550400" },
                    new Technician { Id = 5, Name = "Jason Lee", Email = "jason@sportsprosoftware.com", Phone = "8005550444" }
                );
        }
    }
}
