using URLShortenerV3.Models;
using System;
using System.Linq;

// Data initializer, makes sure the database is created, and adds a data entry if it's empty

namespace URLShortenerV3.Data {
    public static class DataInitializer {

        public static void Initialize(LinkContext context) {

            context.Database.EnsureCreated();

            if (context.Links.Any()) {
                return;
            }

            var links = new Link[] {
                new Link{LongURL="https://google.com",AmountUsed=0, DateCreated = DateTime.Now}
            };

            foreach (Link l in links) {
                context.Add(l);
            }

            context.SaveChanges();

        }

    }

}