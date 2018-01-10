using databasePractice.Models;
using System;
using System.Linq;

namespace databasePractice.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            var users = new User[]
            {
                new User{FirstName="Koji", LastName="Nakagawa", Email="lightupthesky0627@gmail.com"},
                new User{FirstName="Yuji", LastName="Nakagawa", Email="koji.nakagawa88@gmail.com"},
                new User{FirstName="Sayaka", LastName="Kodama", Email="lightupthesky0627@me.com"}
            };

            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}