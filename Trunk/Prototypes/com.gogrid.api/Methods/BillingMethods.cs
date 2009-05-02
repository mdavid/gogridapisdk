using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Web;
using com.gogrid.api;
using System.Xml.Serialization;
using System.Data;

using System.Xml;


namespace com.gogrid.api
{
    public class BillingMethods 
    {
        public static List<BillingSummary> Get_MyBilling_Account()
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.myaccount_billing_get);


            return CallGrid(url);
        }

        private static List<BillingSummary> CallGrid(string url)
        {
            BillingSummary sls = new BillingSummary();
            string response = "";
            List<BillingSummary> bls = new List<BillingSummary>();

            Uri uri = new Uri(url);
            HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create(uri);
            myHttpWebRequest1.Method = "GET";
            myHttpWebRequest1.Accept = "bytes";
            myHttpWebRequest1.Expect = "";
            myHttpWebRequest1.KeepAlive = true;
            myHttpWebRequest1.ContentType = "text/xml";

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
            delegate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslError)
            {
                bool validationResult = true;
                return validationResult;
            };

            try
            {
                XmlDocument ss = new XmlDocument();

                HttpWebResponse myHttpWebResponse3 = (HttpWebResponse)myHttpWebRequest1.GetResponse();
                if ((myHttpWebResponse3.ContentLength > 0))
                {
                    StreamReader str = new StreamReader(myHttpWebResponse3.GetResponseStream());
                    response = str.ReadToEnd();
                    str.Close();

                    ss.LoadXml(response);

                    XmlNodeList Xn = ss.SelectNodes("//list/object[@name='billingsummary']");

                    foreach (XmlNode xnode in Xn)
                    {
                        sls.StartDate = xnode.ChildNodes[0].InnerText;
                        sls.EndDate = xnode.ChildNodes[1].InnerText;
                        sls.MemoryAllotment = xnode.ChildNodes[2].InnerText;
                        sls.MemoryInUse = xnode.ChildNodes[3].InnerText;
                        sls.MemoryAccured = xnode.ChildNodes[4].InnerText;
                        sls.MemoryOverage = xnode.ChildNodes[5].InnerText;
                        sls.MemoryOverageCharge = xnode.ChildNodes[6].InnerText;
                        sls.TransferAllotment = xnode.ChildNodes[7].InnerText;
                        sls.TransferAccorrued = xnode.ChildNodes[8].InnerText;
                        sls.TransferOverage = xnode.ChildNodes[9].InnerText;
                        sls.TransferOverageCharge = xnode.ChildNodes[10].InnerText;

                    }
                }
            }
            catch (WebException we)
            {
                // If reading the normal response body fails we end up here,
                // where we read the error stream and return that and the exception
                // message in a CClientError exception
                response = "This error occur for several: " + we.Message + "\n\n";


            }

            bls.Add(sls);
            //return response;
            return bls;

        }
    }

    
}
