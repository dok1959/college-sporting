using CollegeSporting.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSporting.Data
{
    public static class SeedCountries
    {
        public static void CreateSeedCountries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData
                (
                    new Country { Id = 1, Name = "Switzerland" },
                    new Country { Id = 2, Name = "Canada" },
                    new Country { Id = 3, Name = "Japan" },
                    new Country { Id = 4, Name = "Germany" },
                    new Country { Id = 5, Name = "Australia" }
                );
        }
    }
}
