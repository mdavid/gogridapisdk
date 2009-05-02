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
    public class ServerImageMethods
    {
        public static List<ServerImage> Get_Image_List()
        {
         
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_image_list);

            return CallGrid(url);
        }

        private static List<ServerImage> CallGrid(string url)
        {
            List<ServerImage> sls = new List<ServerImage>();
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

                    XmlNodeList Xn = ss.SelectNodes("//list");

                    foreach (XmlNode xnode in Xn)
                    {



                        //Getting Server Image Information
                        XmlNodeList xnodeImage = xnode.SelectNodes("//object[@name='serverimage']");
                        foreach (XmlNode imageNode in xnodeImage)
                        {
                            ServerImage sImage = new ServerImage();

                            sImage.ID = imageNode.ChildNodes[0].InnerText;
                            sImage.Name = imageNode.ChildNodes[1].InnerText;
                            sImage.FriendlyName = imageNode.ChildNodes[2].InnerText;
                            sImage.Description = imageNode.ChildNodes[3].InnerText;
                            sImage.Location = imageNode.ChildNodes[4].InnerText;
                            sImage.isActive = imageNode.ChildNodes[5].InnerText;
                            sImage.isPublic = imageNode.ChildNodes[6].InnerText;
                            sImage.CreatedTime = imageNode.ChildNodes[7].InnerText;
                            sImage.UpdatedTime = imageNode.ChildNodes[8].InnerText;

                            sls.Add(sImage);
                        }

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


            //return response;
            return sls;

        }

    }
}
