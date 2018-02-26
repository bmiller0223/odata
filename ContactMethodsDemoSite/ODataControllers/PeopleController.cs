using ContactMethodsDemoSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;

namespace ContactMethodsDemoSite.ODataControllers
{
    public class PeopleController : ODataController
    {
        private ContactsContext _model = new ContactsContext();

        protected ContactsContext Model
        {
            get { return _model; }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _model.Dispose();
        }

        public IQueryable<Person> Get()
        {
            return Model.People;
        }


    }
}