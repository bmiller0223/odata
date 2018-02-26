using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Csdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace ContactMethodsDemoSite
{
    public class CsdlReaderWriter
    {
        public CsdlReaderWriter()
        {
            _appDataPath = HttpContext.Current.Server.MapPath($"~\\");
        }
        public void WriteModelToCsdl(IEdmModel model)
        {
            IEnumerable<Microsoft.OData.Edm.Validation.EdmError> errors;
            var writer = XmlWriter.Create($"{_appDataPath}/ODataModel.csdl.xml");
            CsdlWriter.TryWriteCsdl(model, writer, CsdlTarget.OData, out errors);
            writer.Flush();
            writer.Close();
            writer.Dispose();

            var edmErrors = errors as IList<Microsoft.OData.Edm.Validation.EdmError> ?? errors.ToList();
            if (edmErrors.Any())
            {
                throw new Exception(edmErrors.First().ErrorMessage);
            }
        }


        public IEdmModel BuildModelFromXmlFiles()
        {
            IEdmModel model;
            IEnumerable<Microsoft.OData.Edm.Validation.EdmError> errors;
            var reader = XmlReader.Create($"{_appDataPath}/ODataModel.csdl.xml");
            CsdlReader.TryParse(reader, out model, out errors);

            var edmErrors = errors as IList<Microsoft.OData.Edm.Validation.EdmError> ?? errors.ToList();
            if (edmErrors.Any())
            {
                throw new Exception(edmErrors.First().ErrorMessage);
            }

            reader.Close();
            reader.Dispose();
            return model;
        }
        private  string _appDataPath;

    }
}
