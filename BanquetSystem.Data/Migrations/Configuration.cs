namespace BanquetSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BanquetSystem.Data.BanquetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BanquetSystem.Data.BanquetDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            context.Country.AddOrUpdate(
               p => p.CountryName,
               new Country { Id = 1, CountryName = "Pakistan" });

            context.City.AddOrUpdate(
               p => p.CityName,
               new City { Id = 1, CountryId = 1, CityName = "Karachi" },
               new City { Id = 2, CountryId = 1, CityName = "Lahore" }
               );

            context.CustomerType.AddOrUpdate(
               p => p.Name,
               new CustomerType { Id = 1, Name = "Banquet" },
               new CustomerType { Id = 2, Name = "Catering" },
               new CustomerType { Id = 3, Name = "Event Management" }
               );

            context.Event.AddOrUpdate(
               p => p.EventName,
               new Event { Id = 1, EventName = "Marriage" },
               new Event { Id = 2, EventName = "Reception" },
               new Event { Id = 3, EventName = "Birthday" },
               new Event { Id = 4, EventName = "Party" },
               new Event { Id = 5, EventName = "Others" }
               );

            context.Customer.AddOrUpdate(
               p => p.FirstName,
               new Customer
               {
                   Id = 1,
                   CustomerTypeId = 1,
                   UserId="1",
                   FirstName = "Customer Fn",
                   LastName = "Customer Ln",
                   Email="testuser1@test.com",
                   Phone="0215454545455",
                   Mobile="030054545454",
                   AddressLine1 = "Line 1",
                   AddressLine2 = "Line 2",
                   AddressLine3 = "Line 3",
                   CountryId = 1,
                   CityId = 1,
                   CreatedDate = DateTime.Now
               });

            context.CustomerEvent.AddOrUpdate(
               p => p.Id,
               new CustomerEvent { Id = 1, CustomerId=1, EventId = 1 },
               new CustomerEvent { Id = 1, CustomerId = 1, EventId = 2 },
               new CustomerEvent { Id = 1, CustomerId = 1, EventId = 3 });

            context.CustomerEventDetail.AddOrUpdate(
               p => p.Id,
               new CustomerEventDetail { Id = 1, CustomerId = 1, EventId = 1, CostPerHead = 720, Capacity = 30 });

            context.CustomerImage.AddOrUpdate(
               p => p.Id,
               new CustomerImage { Id = 1, CustomerId = 1, Image = @"C:\images\test.png" });

            context.Theme.AddOrUpdate(
               p => p.Id,
               new Theme { Id = 1, ThemeName = "Pink" },
               new Theme { Id = 1, ThemeName = "Red" },
               new Theme { Id = 1, ThemeName = "White" },
               new Theme { Id = 1, ThemeName = "Blue" });
        }
    }
}
