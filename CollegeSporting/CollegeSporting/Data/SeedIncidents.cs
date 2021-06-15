using CollegeSporting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CollegeSporting.Data
{
    public static class SeedIncidents
    {
        public static void CreateSeedIncidents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().HasData
                (
                    new Incident 
                    { 
                        Id = 1, 
                        CustomerId = 5,
                        ProductId = 4,
                        Title = "Could not install",
                        Description = "Why that happens with me?",
                        DateOpened = DateTime.Parse("1/8/2020")
                    },
                    new Incident
                    {
                        Id = 2,
                        CustomerId = 3,
                        ProductId = 1,
                        Title = "Could not install",
                        Description = "Why that happens with me?",
                        DateOpened = DateTime.Parse("1/8/2020"),
                        TechnicianId = 2
                    },
                    new Incident
                    {
                        Id = 3,
                        CustomerId = 2,
                        ProductId = 3,
                        Title = "Error importing data",
                        Description = "Why that happens with me?",
                        DateOpened = DateTime.Parse("1/9/2020")
                    },
                    new Incident
                    {
                        Id = 4,
                        CustomerId = 5,
                        ProductId = 2,
                        Title = "Error launching program",
                        Description = "Why that happens with me?",
                        DateOpened = DateTime.Parse("1/10/2020"),
                        DateClosed = DateTime.Parse("2/11/2020")
                    }
                );
        }
    }
}
