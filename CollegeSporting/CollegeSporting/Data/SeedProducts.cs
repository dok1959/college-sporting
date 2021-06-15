using CollegeSporting.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CollegeSporting.Data
{
    public static class SeedProducts
    {
        public static void CreateSeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
                (
                    new Product { Id = 1, Name = "Tournament Master 1.0", Code = "TRNY10", Price = 4.99M, Release = DateTime.Parse("12/1/2015") },
                    new Product { Id = 2, Name = "Leaugue Scheduler 1.0", Code = "LEAG10", Price = 4.99M, Release = DateTime.Parse("5/1/2016") },
                    new Product { Id = 3, Name = "League Scheduler Deluxe 1.0", Code = "LEAGD10", Price = 7.99M, Release = DateTime.Parse("8/1/2016") },
                    new Product { Id = 4, Name = "Draft Manager 1.0", Code = "DRAFT10", Price = 4.99M, Release = DateTime.Parse("2/1/2017") },
                    new Product { Id = 5, Name = "Team Manager 1.0", Code = "TEAM10", Price = 4.99M, Release = DateTime.Parse("5/1/2017") },
                    new Product { Id = 6, Name = "Tournament Master 2.0", Code = "TRNY20", Price = 5.99M, Release = DateTime.Parse("2/15/2018") },
                    new Product { Id = 7, Name = "Draft Manager 2.0", Code = "DRAFT20", Price = 5.99M, Release = DateTime.Parse("7/15/2019") }
                );
        }
    }
}
