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
    public class ConnectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructionOfConnectionWithNullApikeyFails()
        {
            Connection connection = new Connection(
                null,
                TestConstants.SECRET
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructionOfConnectionWithEmptyApikeyFails()
        {
            Connection connection = new Connection(
                string.Empty,
                TestConstants.SECRET
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructionOfConnectionWithNullSecretFails()
        {
            Connection connection = new Connection(
                TestConstants.API_KEY,
                null
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructionOfConnectionWithEmptySecretFails()
        {
            Connection connection = new Connection(
                TestConstants.API_KEY,
                string.Empty
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructionOfConnectionWithNullInvokerFails()
        {
            Connection connection = new Connection(
                TestConstants.API_KEY,
                TestConstants.SECRET,
                null
                );
        }

        [TestMethod()]
        public void TestConstructionWithJustApikeyAndSecretSucceeds()
        {
            Connection connection = new Connection(
                TestConstants.API_KEY,
                TestConstants.SECRET
                );

            Assert.AreEqual(TestConstants.API_KEY, connection.Apikey);
            Assert.AreEqual(TestConstants.SECRET, connection.Secret);
            Assert.IsNotNull(connection.Invoker);
        }

        [TestMethod()]
        public void TestConstructionWithApikeySecretAndInvokerSucceeds()
        {
            Invoker invoker = new Invoker();

            Connection connection = new Connection(
               TestConstants.API_KEY,
               TestConstants.SECRET,
               invoker
               );

            Assert.AreEqual(TestConstants.API_KEY, connection.Apikey);
            Assert.AreEqual(TestConstants.SECRET, connection.Secret);
            Assert.AreEqual(invoker, connection.Invoker);
        }

        [TestMethod()]
        [DeploymentItem("SampleData\\ImagesListResponseAll.xml", "SampleData")]
        public void TestListImagesWithoutPaging()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\ImagesListResponseAll.xml");
            StubInvoker invoker = new StubInvoker(document);

            Connection connection = new Connection(TestConstants.API_KEY, TestConstants.SECRET, invoker);
            List<Image> images = connection.ListImages();

            Assert.AreEqual(39, images.Count);
        }

        [TestMethod()]
        [DeploymentItem("SampleData\\JobsListResponseAll.xml", "SampleData")]
        public void TestListJobsWithoutPaging()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\JobsListResponseAll.xml");
            StubInvoker invoker = new StubInvoker(document);

            Connection connection = new Connection(TestConstants.API_KEY, TestConstants.SECRET, invoker);
            List<Job> jobs = connection.ListJobs();

            Assert.AreEqual(7, jobs.Count);
        }

        [TestMethod()]
        [DeploymentItem("SampleData\\ServersListResponseAll.xml", "SampleData")]
        public void TestListServersWithoutPaging()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\ServersListResponseAll.xml");
            StubInvoker invoker = new StubInvoker(document);

            Connection connection = new Connection(TestConstants.API_KEY, TestConstants.SECRET, invoker);
            List<Server> servers = connection.ListServers();

            Assert.AreEqual(1, servers.Count);
        }

        [TestMethod()]
        [DeploymentItem("SampleData\\LoadBalancersListResponseAll.xml", "SampleData")]
        public void TestListLoadBalancersWithoutPaging()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\LoadBalancersListResponseAll.xml");
            StubInvoker invoker = new StubInvoker(document);

            Connection connection = new Connection(TestConstants.API_KEY, TestConstants.SECRET, invoker);
            List<LoadBalancer> loadBalancers = connection.ListLoadBalancers();

            Assert.AreEqual(1, loadBalancers.Count);
        }

        [TestMethod()]
        [DeploymentItem("SampleData\\IPAddressesListResponseAll.xml", "SampleData")]
        public void TestListIPAddressesWithoutPaging()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\IPAddressesListResponseAll.xml");
            StubInvoker invoker = new StubInvoker(document);

            Connection connection = new Connection(TestConstants.API_KEY, TestConstants.SECRET, invoker);
            List<IPAddress> addresses = connection.ListIPAddresses();

            Assert.AreEqual(5, addresses.Count);
        }

        [TestMethod()]
        [DeploymentItem("SampleData\\ServerPasswordsListResponseAll.xml", "SampleData")]
        public void TestListServerPasswordsWithoutPaging()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\ServerPasswordsListResponseAll.xml");
            StubInvoker invoker = new StubInvoker(document);

            Connection connection = new Connection(TestConstants.API_KEY, TestConstants.SECRET, invoker);
            List<ServerPassword> passwords = connection.ListServerPasswords();

            Assert.AreEqual(1, passwords.Count);
        }

        [TestMethod()]
        [DeploymentItem("SampleData\\OptionsListResponseAll.xml", "SampleData")]
        public void TestListOptionsWithoutPaging()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\OptionsListResponseAll.xml");
            StubInvoker invoker = new StubInvoker(document);

            Connection connection = new Connection(TestConstants.API_KEY, TestConstants.SECRET, invoker);
            List<Option> options = connection.ListOptions("server.ram");

            Assert.AreEqual(3, options.Count);
        }

        [TestMethod()]
        [DeploymentItem("SampleData\\JobsDateRangeResponse.xml", "SampleData")]
        public void TestListJobsWithDateRange()
        {
            XmlDocument document = new XmlDocument();
            document.Load("SampleData\\JobsDateRangeResponse.xml");
            StubInvoker invoker = new StubInvoker(document);

            Connection connection = new Connection(TestConstants.API_KEY, TestConstants.SECRET, invoker);
            List<Job> jobs = connection.ListJobs(
                DateRange.Between("05/01/2009", "04/25/2009"),
                JobObjectType.Any,
                JobState.Any,
                Owner.Any,
                JobObjectName.Any,
                Paging.None
                );
        }
    }
}
