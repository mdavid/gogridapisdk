using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class Server
    {
        public Connection Connection { get; set; }

        public static Server CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            Server output = new Server();
            output.Connection = connection;

            output.ID = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableInt32(objectElementNode, "id");
            output.Name = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "name");
            output.Description = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "description");

            XmlNode ipAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "ip");
            output.IPAddress = IPAddress.CreateFromXmlNode(ipAttributeXmlNode, connection);

            XmlNode memoryAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "ram");
            output.Memory = Option.CreateFromXmlNode(memoryAttributeXmlNode, connection);

            XmlNode imageAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "image");
            output.Image = Image.CreateFromXmlNode(imageAttributeXmlNode, connection);

            XmlNode stateAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "state");
            output.State = Option.CreateFromXmlNode(stateAttributeXmlNode, connection);

            XmlNode typeAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "type");
            output.Type = Option.CreateFromXmlNode(typeAttributeXmlNode, connection);

            XmlNode operatingSystemAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "os");
            output.OperatingSystem = Option.CreateFromXmlNode(operatingSystemAttributeXmlNode, connection);

            return output;
        }

        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IPAddress IPAddress { get; set; }
        public Option Memory { get; set; }
        public Image Image { get; set; }
        public Option State { get; set; }
        public Option Type { get; set; }
        public Option OperatingSystem { get; set; }
    }
}
