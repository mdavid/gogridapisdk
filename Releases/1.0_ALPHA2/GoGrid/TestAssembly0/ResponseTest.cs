using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoGrid;
using System.Xml;

namespace TestAssembly0
{
    [TestClass]
    public class ResponseTest
    {
        [TestMethod]
        [DeploymentItem("SampleData\\ImagesListResponse5.xml", "SampleData")]
        public void TestResponseReadsSummaryDataFromReturnedDocument()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\ImagesListResponse5.xml");
            Response response = new Response(document);

            Assert.AreEqual(39, response.TotalObjects);
            Assert.AreEqual(10, response.FirstObjectIndex);
            Assert.AreEqual(8, response.TotalPages);
            Assert.AreEqual(5, response.PageSize);
            Assert.AreEqual(2, response.CurrentPageIndex);

            XmlNodeList objectNodes = response.GetObjectNodes("serverimage");
            Assert.AreEqual(5, objectNodes.Count);
        }
    }
}
