namespace ContactMethodsDemoSite.Migrations
{
    using ContactMethodsDemoSite.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactMethodsDemoSite.Entities.ContactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactMethodsDemoSite.Entities.ContactsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var people = new List<Person>()
            {
                new Person{
                    FirstName = "Andre",
                    LastName = "Thomson",
                    Gender = "M",
                    ContactMethods = new List<ContactMethod>
                    {
                        new ContactMethod { ContactType = "E", ContactText = "athomson@gmail.com" },
                        new ContactMethod { ContactType = "A", ContactText = "7803 S 56th Ave, Miami, FL"}
                    }
                },
                new Person
                {
                    FirstName = "Mia",
                    LastName = "Barnes",
                    Gender = "F",
                    ContactMethods = new List<ContactMethod>
                    {
                        new ContactMethod{ContactType = "E", ContactText = "mbarnes@hotmail.com" },
                        new ContactMethod{ContactType = "P", ContactText = "(954) 376-3322"}
                    }
                
                }
            };

            people.ForEach(p => context.People.AddOrUpdate(c => c.LastName, p));
            context.SaveChanges();

        }
    }
}
