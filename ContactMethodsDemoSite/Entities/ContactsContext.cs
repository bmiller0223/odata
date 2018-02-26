using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ContactMethodsDemoSite.Entities
{
    public class ContactsContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<ContactMethod> ContactMethods { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}