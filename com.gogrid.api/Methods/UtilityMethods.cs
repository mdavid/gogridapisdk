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
    public class UtilityMethods
    {
        
        public static List<Option> Get_Common_LookUp_List_ByLookUp(string lookup)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.common_lookup_list);
            url += "&lookup=" + lookup;

            return GetLookUp(url);

        }
        /*      // Use the generic function Get_Common_LookUp_List_By_Param instead of this.
                public static List<Option> Get_Common_LookUp_List_ByLookUp_Sort(string sort)
                {
                    // Start constructing the request URL, starting with the server and method
                    string url = GlobalVariables.GetUrl(GlobalVariables.common_lookup_list);
                    url += "&lookup=lookups" +
                        "&sort=" + sort;

                    return GetLookUp(url);

                }
         */

        public static List<Option> Get_Common_LookUp_List_By_Param(string method, System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(method);
            
            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + HttpUtility.UrlEncode(d.Value.ToString());
                }
            }

            List<Option> options = GetLookUp(url);

            return options;
        }

        public static List<Option> GetLookUp(string url)
        {
            List<Option> options = new List<Option>();
            string response = "";

            Messages msg = new Messages();

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

                
                HttpWebResponse myHttpWebResponse3 = (HttpWebResponse)myHttpWebRequest1.GetResponse();
                if ((myHttpWebResponse3.ContentLength > 0))
                {
                    StreamReader str = new StreamReader(myHttpWebResponse3.GetResponseStream());
                    response = str.ReadToEnd();
                    str.Close();

                    if (response.Contains("sucsess"))
                    {
                        msg.Success = true;
                    }
                    
                    //Passing the response to xml format
                    XmlDocument ss = new XmlDocument();
                    ss.LoadXml(response);
                    XmlNodeList Xn = ss.SelectNodes("//object[@name='option']");

                    foreach (XmlNode xnode in Xn)
                    {


                            Option option = new Option();

                            option.ID = xnode.ChildNodes[0].InnerText;
                            option.Name = xnode.ChildNodes[1].InnerText;
                            option.Description = xnode.ChildNodes[2].InnerText;
                            option.message = msg;
                            options.Add(option);

                    }
                }
            }
            catch (WebException we)
            {
                // If reading the normal response body fails we end up here,
                // where we read the error stream and return that and the exception
                // message in a CClientError exception
                response = "This error occur for several: " + we.Message + "\n\n";
                msg.Error_400 = response.Contains("400") == true ? response.ToString() : "";
                msg.Error_401 = response.Contains("401") == true ? response.ToString() : "";
                msg.Error_403 = response.Contains("403") == true ? response.ToString() : "";
                msg.Error_404 = response.Contains("404") == true ? response.ToString() : "";
                msg.Error_500 = response.Contains("500") == true ? response.ToString() : "";
                Option option = new Option();
                option.message = msg;

                options.Add(option);

            }

            return options;
        }

    }
}
