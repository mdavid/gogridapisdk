using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class IPAddress
    {
        public IPAddress()
        {
        }

        public IPAddress(string address)
        {
            this.Address = address;
        }

        public Connection Connection { get; set; }

        public static IPAddress CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            IPAddress output = new IPAddress();
            output.Connection = connection;

            output.ID = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableInt32(objectElementNode, "id");
            output.Address = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "ip");
            output.Subnet = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "subnet");
            output.IsPublic = InternalHelper.GetAttributeElementValueFromXmlNodeAsBoolean(objectElementNode, "public");

            return output;
        }

        public int? ID { get; set; }
        public string Address { get; set; }
        public string Subnet { get; set; }
        public bool IsPublic { get; set; }
    }
}
