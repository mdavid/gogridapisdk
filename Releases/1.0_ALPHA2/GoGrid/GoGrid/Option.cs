using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class Option
    {
        public Connection Connection { get; set; }

        public static Option CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            Option output = new Option();
            output.Connection = connection;

            output.ID = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableInt32(objectElementNode, "id");
            output.Name = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "name");
            output.Description = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "description");

            return output;
        }

        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
