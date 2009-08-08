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
    public class JobHistoryTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\JobHistory.xml", "SampleData")]
        public void TestReadGoGridJobHistoryFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\JobHistory.xml");

            JobHistory jobHistory = JobHistory.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
