using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class ServerPassword
    {
        public Connection Connection { get; set; }

        public static ServerPassword CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            ServerPassword output = new ServerPassword();
            output.Connection = connection;

            output.ID = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableInt32(objectElementNode, "id");

            XmlNode serverAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "server");
            output.Server = Server.CreateFromXmlNode(serverAttributeXmlNode, connection);

            output.ApplicationType = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "applicationtype");
            output.Username = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "username");
            output.Password = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "password");


            return output;
        }

        public int? ID { get; set; }
        public Server Server { get; set; }
        public string ApplicationType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
