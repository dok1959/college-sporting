using CollegeSporting.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSporting.Data
{
    public static class SeedCustomers
    {
        public static void CreateSeedCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData
                (
                    new Customer 
                    { 
                        Id = 1,
                        FirstName = "Kaitlyn", 
                        LastName = "Anthoni", 
                        Address = "221B Baker Street",
                        City = "San Francisco",
                        State = "Nice state",
                        PostalCode = "1020304049",
                        CountryId = 2,
                        Email = "kanthoni@pge.com",
                        Phone = "1002003000"
                    },
                    
                    new Customer 
                    {
                        Id = 2,
                        FirstName = "Ania",
                        LastName = "Irvin",
                        Address = "221B Baker Street",
                        City = "Washington",
                        State = "Nice state",
                        PostalCode = "1020304049",
                        CountryId = 3,
                        Email = "ania@mma.nidc.com",
                        Phone = "1002003000"
                    },
                    
                    new Customer 
                    {
                        Id = 3,
                        FirstName = "Gonzalo",
                        LastName = "Keeton",
                        Address = "221B Baker Street",
                        City = "Mission Viejo",
                        State = "Nice state",
                        PostalCode = "1020304049",
                        CountryId = 4,
                        Email = "",
                        Phone = "1002003000"
                    },
                    
                    new Customer 
                    {
                        Id = 4,
                        FirstName = "Anton",
                        LastName = "Mauro",
                        Address = "221B Baker Street",
                        City = "Sacramento",
                        State = "Nice state",
                        PostalCode = "1020304049",
                        CountryId = 1,
                        Email = "amauro@yahoo.org",
                        Phone = "1002003000"
                    },
                    
                    new Customer 
                    { 
                        Id = 5,
                        FirstName = "Kendall",
                        LastName = "Mayte",
                        Address = "221B Baker Street",
                        City = "Fresno",
                        State = "Nice state",
                        PostalCode = "1020304049",
                        CountryId = 1,
                        Email = "kmayte@fresno.ca.gov",
                        Phone = "1002003000"
                    },
                    
                    new Customer 
                    { 
                        Id = 6,
                        FirstName = "Kenzie",
                        LastName = "Quinn",
                        Address = "221B Baker Street",
                        City = "Los Angeles",
                        State = "Nice state",
                        PostalCode = "1020304049",
                        CountryId = 2,
                        Email = "kenzie@mma.jobtrak.com",
                        Phone = "1002003000"
                    },
                    
                    new Customer 
                    { 
                        Id = 7,
                        FirstName = "Marvin",
                        LastName = "Quintin",
                        Address = "221B Baker Street",
                        City = "Fresno",
                        State = "Nice state",
                        PostalCode = "1020304049",
                        CountryId = 5,
                        Email = "marvin@expedata.com",
                        Phone = "1002003000"
                    }
                );
        }
    }
}
