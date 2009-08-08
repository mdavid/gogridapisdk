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
    public class ServerTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\Server.xml", "SampleData")]
        public void TestReadGoGridServerFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\Server.xml");

            Server server = Server.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
