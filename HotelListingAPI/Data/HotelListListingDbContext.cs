using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace HotelListingAPI.Data
{
    public class HotelListListingDbContext : DbContext
    {
        public HotelListListingDbContext(DbContextOptions options) : base(options) {
        
        }
            public DbSet<Hotel> Hotels { get; set; }
            public DbSet<Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name= "Republica Dominicana",
                    ShortName="RD"
                },
                new Country
                {
                    Id = 2,
                    Name = "Jamaica",
                    ShortName = "JM"
                }  
            );
            modelBuilder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "El Gran Hotel",
                   Address ="Santo Domingo",
                   CountryId=1,
                   Rating=4.3
               },
               new Hotel
               {
                   Id = 2,
                   Name = "El Jamaiquino",
                   Address = "Negril",
                   CountryId = 2,
                   Rating = 4.2
               }
           );
        }
    }
}
