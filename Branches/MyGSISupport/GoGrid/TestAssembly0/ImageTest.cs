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
    public class ImageTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\Image.xml", "SampleData")]
        public void TestReadGoGridImageFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\Image.xml");

            Image image = Image.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
