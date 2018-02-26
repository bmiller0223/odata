using ContactMethodsDemoSite.Entities;
using Microsoft.Data.Edm.Validation;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ContactMethodsDemoSite
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            BuildODataModel(config);
            BuildODataModelFromXml(config);

            // configure OData controller
            config.Expand().Select().AddODataQueryFilter(new EnableQueryAttribute { MaxNodeCount = 2000, MaxExpansionDepth = 3, MaxOrderByNodeCount = 1000, MaxAnyAllExpressionDepth = 999 });
        }
        private static void BuildODataModel(HttpConfiguration config)
        {
            // build the model using the OData Builder
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Person>("People");
            builder.EntitySet<ContactMethod>("ContactMethods");

            // add a function
            builder.Namespace = "CampusNexus";
            builder.EntityType<ContactMethod>().Collection
                .Function("GetAllEmails")
                .ReturnsCollectionFromEntitySet<ContactMethod>("ContactMethods");
            var edmModel = builder.GetEdmModel();
            config.MapODataServiceRoute("odataFromBuilder", "ds/modelFromBuilder", edmModel);

            // save the model to XML
            var csdl = new CsdlReaderWriter();
            csdl.WriteModelToCsdl(edmModel);

        }
        private static void BuildODataModelFromXml(HttpConfiguration config)
        {
            // Build the model from XML files, map separate endpoint
            var csdl = new CsdlReaderWriter();
            var modelFromXml = csdl.BuildModelFromXmlFiles();
            config.MapODataServiceRoute("odataFromXml", "ds/modelFromXml", modelFromXml);
        }
    }
}
