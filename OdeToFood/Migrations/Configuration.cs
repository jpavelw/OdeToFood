namespace OdeToFood.Migrations
{
    using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDB context)
        {
            // goes into the db and look up by name. checks if it exists and it will update that record
            // if it does not exists, it will add the record
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
                new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
                new Restaurant
                {
                    Name = "Smaka",
                    City = "Gothenburg",
                    Country = "Sweden",
                    Reviews =
                        new List<RestaurantReview> {
                            new RestaurantReview { Rating = 9, Body = "Great food!", ReviewerName = "Yahir" }
                        }
                });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
