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
    public class InvokerTest
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExecuteWithNullUrlParameter()
        {
            Invoker invoker = new Invoker();
            invoker.Invoke(
                null,
                TestConstants.API_KEY,
                TestConstants.SECRET,
                TestConstants.VERSION,
                null
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExecuteWithEmptyUrlParameter()
        {
            Invoker invoker = new Invoker();
            invoker.Invoke(
                string.Empty,
                TestConstants.API_KEY,
                TestConstants.SECRET,
                TestConstants.VERSION,
                null
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExecuteWithNullApiKeyParameter()
        {
            Invoker dispatcher = new Invoker();
            dispatcher.Invoke(
                "https://api.gogrid.com/api/myaccount/billing/get",
                null,
                TestConstants.SECRET,
                TestConstants.VERSION,
                null
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExecuteWithEmptyApiKeyParameter()
        {
            Invoker invoker = new Invoker();
            invoker.Invoke(
                "https://api.gogrid.com/api/myaccount/billing/get",
                string.Empty,
                TestConstants.SECRET,
                TestConstants.VERSION,
                null
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExecuteWithNullSecretParameter()
        {
            Invoker invoker = new Invoker();
            invoker.Invoke(
                "https://api.gogrid.com/api/myaccount/billing/get",
                TestConstants.API_KEY,
                null,
                TestConstants.VERSION,
                null
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExecuteWithEmptySecretParameter()
        {
            Invoker invoker = new Invoker();
            invoker.Invoke(
                "https://api.gogrid.com/api/myaccount/billing/get",
                TestConstants.API_KEY,
                string.Empty,
                TestConstants.VERSION,
                null
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExecuteWithNullVersionParameter()
        {
            Invoker invoker = new Invoker();
            invoker.Invoke(
                "https://api.gogrid.com/api/myaccount/billing/get",
                TestConstants.API_KEY,
                TestConstants.SECRET,
                null,
                null
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExecuteWithEmptyVersionParameter()
        {
            Invoker invoker = new Invoker();
            invoker.Invoke(
                "https://api.gogrid.com/api/myaccount/billing/get",
                TestConstants.API_KEY,
                TestConstants.SECRET,
                string.Empty,
                null
                );
        }

        [TestMethod()]
        public void TestExecuteWithValidParametersWithNoAdditionalParameters()
        {
            Invoker invoker = new Invoker();
            XmlDocument document = invoker.Invoke(
                "https://api.gogrid.com/api/myaccount/billing/get",
                TestConstants.API_KEY,
                TestConstants.SECRET,
                TestConstants.VERSION,
                null
                );

            Assert.IsNotNull(document, "GoGridHelper.Execute(...) returned a null value.");
            XmlNode responseElement = document.SelectSingleNode("//response[@status = 'success']");
            Assert.IsNotNull(responseElement, "GoGridHelper.Execute(...) returned an XmlDocument with no success response.");
        }

        [TestMethod()]
        public void TestExecuteWithValidParamtersAndAdditionalParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string,string>();
            parameters.Add("ip.state", "Unassigned");

            Invoker invoker = new Invoker();
            XmlDocument document = invoker.Invoke(
                "https://api.gogrid.com/api/grid/ip/list",
                TestConstants.API_KEY,
                TestConstants.SECRET,
                TestConstants.VERSION,
                parameters
                );

            Assert.IsNotNull(document, "GoGridHelper.Execute(...) returned a null value.");
            XmlNode responseElement = document.SelectSingleNode("//response[@status = 'success']");
            Assert.IsNotNull(responseElement, "GoGridHelper.Execute(...) returned an XmlDocument with no success response.");
        }
    }
}
