using System;
using System.Collections.Generic;

using System.Text;

using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;
using System.Net.Security;
using System.Web;

namespace com.gogrid.api
{
    public class IPMethods
    {
        public static List<Ip> Get_IP_List()
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_ip_list);

            
            return GetIPSList(url);

        }

        public static List<Ip> Get_IP_List(string method,System.Collections.Hashtable _params)
        {
            string url = GlobalVariables.GetUrl(method);

            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + HttpUtility.UrlEncode(d.Value.ToString());
                }
            }

            return GetIPSList(url);

        }

        public static List<Ip> Get_IP_List(System.Collections.Hashtable _params)
        {
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_ip_list);

            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + HttpUtility.UrlEncode(d.Value.ToString());
                }
            }

            return GetIPSList(url);

        }

        public static List<Ip> Get_IP_List_Unassigned_Private()
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_ip_list);
            url += "&ip.state=Unassigned" +
                "&ip.type=Private";


            return GetIPSList(url);

        }

        public static List<Ip> Get_IP_List_Unassigned_Public()
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_ip_list);
            url += "&ip.state=Unassigned" +
                "&ip.type=Public";

            return GetIPSList(url);

        }

        private static string isPublic(bool ispub)
        {
            if(ispub)
            {
                return "Public";
            }
            else
            {
                return "Private";
            }
        }

        public static List<Ip> Get_IP_List_ByID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_ip_list);
            url += "&id=" + id;

            return GetIPSList(url);

        }
        
        // Calling The Grid Function
        private static List<Ip> GetIPSList(string url)
        {
            Messages messages = new Messages();
            Ip sl;

            List<Ip> sls = new List<Ip>();
            string response = "";

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
                    
                    XmlNodeList Xn = ss.SelectNodes("//object[@name='ip']");

                    foreach (XmlNode xnode in Xn)
                    {


                        sl = new Ip();

                        sl.ID = xnode.ChildNodes[0].InnerText;
                        sl.IP = xnode.ChildNodes[1].InnerText;
                        sl.Subnet = xnode.ChildNodes[2].InnerText;
                        sl.Public = xnode.ChildNodes[3].InnerText;
                        messages = new Messages();
                        messages.Success = true;
                        sl.Message = messages;
                        sls.Add(sl);
                    }
                }
            }
            catch (WebException we)
            {
                // If reading the normal response body fails we end up here,
                // where we read the error stream and return that and the exception
                // message in a CClientError exception
                response = "This error occur for several: " + we.Message + "\n\n";
                Console.WriteLine(response);

                messages.Error_400 = response.Contains("400") == true ? response.ToString() : "";
                messages.Error_401 = response.Contains("401") == true ? response.ToString() : "";
                messages.Error_403 = response.Contains("403") == true ? response.ToString() : "";
                messages.Error_404 = response.Contains("404") == true ? response.ToString() : "";
                messages.Error_500 = response.Contains("500") == true ? response.ToString() : "";
                messages.Success = false;
                sl = new Ip();
                sl.Message = messages;
                sls.Add(sl);
            }
            return sls;
        }



    }
}
