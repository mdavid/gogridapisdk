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
    public class JobTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\Job.xml", "SampleData")]
        public void TestReadGoGridJobFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\Job.xml");

            Job job = Job.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
