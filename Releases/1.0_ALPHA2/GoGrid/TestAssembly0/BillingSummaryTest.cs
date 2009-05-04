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
    public class BillingSummaryTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\BillingSummary.xml", "SampleData")]
        public void TestReadGoGridServerFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\BillingSummary.xml");

            BillingSummary billingSummary = BillingSummary.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
