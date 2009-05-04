using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using GoGrid;

namespace TestAssembly0
{
    [TestClass()]
    public class IPAddressTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\IPAddress.xml", "SampleData")]
        public void TestReadGoGridIPAddressFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\IPAddress.xml");

            IPAddress ipAddress = IPAddress.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
