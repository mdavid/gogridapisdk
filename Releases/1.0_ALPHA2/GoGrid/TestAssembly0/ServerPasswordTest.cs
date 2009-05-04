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
    public class ServerPasswordTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\ServerPassword.xml", "SampleData")]
        public void TestReadGoGridServerPasswordFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\ServerPassword.xml");

            ServerPassword serverPassword = ServerPassword.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
