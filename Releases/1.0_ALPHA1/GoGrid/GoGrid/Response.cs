using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class Response
    {
        public Response(XmlDocument document)
        {
            document.ThrowIfNull("document");
            this.Document = document;
        }

        public XmlDocument Document { get; set; }

        public int TotalObjects
        {
            get
            {
                XmlNode node = this.Document.SelectSingleNode("/gogrid/response/summary/@total");
                string totalString = node.Value;
                int total = int.Parse(totalString);
                return total;
            }
        }

        public int TotalPages
        {
            get
            {
                XmlNode node = this.Document.SelectSingleNode("/gogrid/response/summary/@numpages");
                string totalString = node.Value;
                int total = int.Parse(totalString);
                return total;
            }
        }

        public int FirstObjectIndex
        {
            get
            {
                XmlNode node = this.Document.SelectSingleNode("/gogrid/response/summary/@start");
                string indexString = node.Value;
                int index = int.Parse(indexString);
                return index;
            }
        }

        public int PageSize
        {
            get
            {
                XmlNode node = this.Document.SelectSingleNode("/gogrid/response/summary/@returned");
                string sizeString = node.Value;
                int size = int.Parse(sizeString);
                return size;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return this.FirstObjectIndex / this.PageSize;
            }
        }

        public XmlNodeList GetObjectNodes(string name)
        {
            string xpath = string.Format("/gogrid/response/list/object[@name = '{0}']", name);
            return this.Document.SelectNodes(xpath);
        }
    }
}
