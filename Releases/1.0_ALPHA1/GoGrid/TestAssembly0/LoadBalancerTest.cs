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
    public class LoadBalancerTest
    {
        [TestMethod()]
        [DeploymentItem("SampleData\\LoadBalancer.xml", "SampleData")]
        public void TestReadGoGridLoadBalancerFromXmlNode()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\LoadBalancer.xml");

            LoadBalancer loadBalancer = LoadBalancer.CreateFromXmlNode(document.DocumentElement, null);
        }
    }
}
