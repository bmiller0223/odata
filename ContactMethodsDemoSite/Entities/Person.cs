using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactMethodsDemoSite.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<ContactMethod> ContactMethods { get; set; }
    }
}