using CollegeSporting.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSporting.Data
{
    public static class SeedRegistrations
    {
        public static void CreateSeedRegistrations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasData
                (
                    new Registration { Id = 1, CustomerId = 5, ProductId = 4 },
                    new Registration { Id = 2, CustomerId = 3, ProductId = 1 },
                    new Registration { Id = 3, CustomerId = 2, ProductId = 3 },
                    new Registration { Id = 4, CustomerId = 5, ProductId = 2 }
                );
        }
    }
}
