using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactMethodsDemoSite.Entities
{
    public class ContactMethod
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string ContactType { get; set; }

        public string ContactText { get; set; }

        public virtual Person Person { get; set; }
    }
}