using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoGrid;
using System.Xml;

namespace TestAssembly0
{
    public class StubInvoker : Invoker
    {
        public StubInvoker(XmlDocument document)
        {
            this.m_Document = document;
        }

        private XmlDocument m_Document = null;

        public override System.Xml.XmlDocument Invoke(string url, string apikey, string secret, string version, Dictionary<string, string> parameters)
        {
            return this.m_Document;
        }
    }
}
