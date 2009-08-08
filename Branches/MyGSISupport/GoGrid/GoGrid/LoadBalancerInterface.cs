using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace GoGrid
{
    public class LoadBalancerInterface
    {
        public LoadBalancerInterface()
        {
        }

        public LoadBalancerInterface(IPAddress address, int port)
        {
            this.Address = address;
            this.Port = port;
        }

        public LoadBalancerInterface(string address, int port)
        {
            IPAddress addressObject = new IPAddress(address);
            this.Address = addressObject;
            this.Port = port;
        }

        public Connection Connection { get; set; }

        public static LoadBalancerInterface CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            LoadBalancerInterface output = new LoadBalancerInterface();
            output.Connection = connection;

            XmlNode ipAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "ip");
            output.Address = IPAddress.CreateFromXmlNode(ipAttributeXmlNode, connection);

            output.Port = InternalHelper.GetAttributeElementValueFromXmlNodeAsInt32(objectElementNode, "port");

            return output;
        }

        public IPAddress Address { get; set; }
        public int Port { get; set; }
    }
}
