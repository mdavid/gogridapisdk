using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class LoadBalancer
    {
        public Connection Connection { get; set; }

        public static LoadBalancer CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            LoadBalancer output = new LoadBalancer();
            output.Connection = connection;

            output.ID = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableInt32(objectElementNode, "id");
            output.Name = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "name");
            output.Description = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "description");

            XmlNode virtualInterfaceAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "virtualip");
            output.VirtualInterface = LoadBalancerInterface.CreateFromXmlNode(virtualInterfaceAttributeXmlNode, connection);

            XmlNode realInterfacesAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsXmlNode(objectElementNode, "realiplist");
            XmlNodeList realInterfacesXmlNodeList = realInterfacesAttributeXmlNode.SelectNodes("list/object[@name = 'ipportpair']");

            List<LoadBalancerInterface> temporaryRealInterfaceList = new List<LoadBalancerInterface>();
            foreach (XmlNode realInterfacesXmlNode in realInterfacesXmlNodeList)
            {
                LoadBalancerInterface realInterface = LoadBalancerInterface.CreateFromXmlNode(realInterfacesXmlNode, connection);
                temporaryRealInterfaceList.Add(realInterface);
            }
            output.RealInterfaces = temporaryRealInterfaceList.ToArray();

            XmlNode typeAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "type");
            output.Type = Option.CreateFromXmlNode(typeAttributeXmlNode, connection);

            XmlNode persistenceAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "persistence");
            output.Persistence = Option.CreateFromXmlNode(persistenceAttributeXmlNode, connection);

            XmlNode operatingSystemAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "os");
            output.OperatingSystem = Option.CreateFromXmlNode(operatingSystemAttributeXmlNode, connection);

            XmlNode stateAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "state");
            output.State = Option.CreateFromXmlNode(stateAttributeXmlNode, connection);

            return output;
        }

        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LoadBalancerInterface VirtualInterface { get; set; }
        public LoadBalancerInterface[] RealInterfaces { get; set; }
        public Option Type { get; set; }
        public Option Persistence { get; set; }
        public Option OperatingSystem { get; set; }
        public Option State { get; set; }
    }
}
