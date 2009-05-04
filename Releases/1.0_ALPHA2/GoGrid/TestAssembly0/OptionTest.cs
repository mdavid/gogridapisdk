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
    public class OptionTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\Option.xml", "SampleData")]
        public void TestReadGoGridOptionFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\Option.xml");

            Option option = Option.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
