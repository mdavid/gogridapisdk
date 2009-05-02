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
    public class PasswordMethods
    {
        public static List<PasswordList> Support_Password_List()
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.support_password_list);

            return CallingGrid(url);
            
        }

        public static List<PasswordList> Support_Password_List(System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.support_password_list);

            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + d.Value;
                }
            }

            return CallingGrid(url);

        }

        public static List<PasswordList> Support_Password_List(string method,System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(method);

            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + d.Value;
                }
            }

            return CallingGrid(url);

        }

        public static List<PasswordList> Support_Password_List_Get_By_ID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.support_password_get);
            url += "&id=" + id;

            return CallingGrid(url);
        }

        public static List<PasswordList> Support_Password_List_Get(string method, System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(method);

            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + d.Value;
                }
            }

            return CallingGrid(url);
        }
        
        public static List<PasswordList> Support_Password_List_Get(System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.support_password_get);
            
            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + d.Value;
                }
            }

            return CallingGrid(url);
        }

        public static List<PasswordList> Support_Password_List_Get_By_Password(string password)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.support_password_get);
            url += "&password=" + password;

            return CallingGrid(url);
        }

        private static List<PasswordList> CallingGrid(string url)
        {
            Messages messages = new Messages();
            PasswordList ps;
            ServerList sl;

            List<PasswordList> sls = new List<PasswordList>();
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
                //ss.Load(uri.ToString());


                HttpWebResponse myHttpWebResponse3 = (HttpWebResponse)myHttpWebRequest1.GetResponse();
                if ((myHttpWebResponse3.ContentLength > 0))
                {
                    StreamReader str = new StreamReader(myHttpWebResponse3.GetResponseStream());
                    response = str.ReadToEnd();
                    str.Close();
                    ss.LoadXml(response);

                    if (response.Contains("success"))
                    {
                        messages.Success = true;
                    }

                    XmlNodeList Xn = ss.SelectNodes("//object[@name='password']");

                    foreach (XmlNode xnode in Xn)
                    {
                        sl = new ServerList();

                        ps = new PasswordList();

                        
                        if (xnode.ChildNodes.Count == 5)
                        {
                            ps.ID = xnode.ChildNodes[0].InnerText;
                            ps.ApplicationType = xnode.ChildNodes[2].InnerText;
                            ps.UserName = xnode.ChildNodes[3].InnerText;
                            ps.Password = xnode.ChildNodes[4].InnerText;

                        }
                        else
                        {
                            ps.ID = xnode.ChildNodes[0].InnerText;
                            ps.ApplicationType = xnode.ChildNodes[1].InnerText;
                            ps.UserName = xnode.ChildNodes[2].InnerText;
                            ps.Password = xnode.ChildNodes[3].InnerText;

                        }
                        
#region RestOf the Info
		                        ////Getting IP Information

                        //XmlNodeList xServer = xnode.SelectNodes("//object[@name='server']");
                        //foreach (XmlNode serverNode in xServer)
                        //{
                            

                        //    sl.ID = serverNode.ChildNodes[0].InnerText;
                        //    sl.Name = serverNode.ChildNodes[1].InnerText;
                        //    sl.Description = serverNode.ChildNodes[2].InnerText;


                        //    XmlNodeList xnodeip = xnode.SelectNodes("//object[@name='server']");
                        //    foreach (XmlNode ipNode in xnodeip)
                        //    {
                        //        Ip ipNew = new Ip();
                        //        ipNew.ID = ipNode.ChildNodes[0].InnerText;
                        //        ipNew.IP = ipNode.ChildNodes[1].InnerText;
                        //        ipNew.Subnet = ipNode.ChildNodes[2].InnerText;
                        //        ipNew.Public = ipNode.ChildNodes[3].InnerText;
                        //        sl.ServerIP = ipNew;
                        //    }

                        //    //Getting the Ram Information
                        //    XmlNodeList xnoderam = xnode.SelectNodes("//attribute[@name='ram']/object");
                        //    foreach (XmlNode ramNode in xnoderam)
                        //    {
                        //        Ram ramNew = new Ram();

                        //        ramNew.ID = ramNode.ChildNodes[0].InnerText;
                        //        ramNew.Name = ramNode.ChildNodes[1].InnerText;
                        //        ramNew.Description = ramNode.ChildNodes[2].InnerText;
                        //        sl.ServerRam = ramNew;
                        //    }

                        //    //Getting Server Image Information
                        //    XmlNodeList xnodeImage = xnode.SelectNodes("//attribute[@name='image']/object");
                        //    foreach (XmlNode imageNode in xnodeImage)
                        //    {
                        //        ServerImage sImage = new ServerImage();

                        //        sImage.ID = imageNode.ChildNodes[0].InnerText;
                        //        sImage.Name = imageNode.ChildNodes[1].InnerText;
                        //        sImage.FriendlyName = imageNode.ChildNodes[2].InnerText;
                        //        sImage.Description = imageNode.ChildNodes[3].InnerText;
                        //        sImage.Location = imageNode.ChildNodes[4].InnerText;
                        //        sImage.isActive = imageNode.ChildNodes[5].InnerText;
                        //        sImage.isPublic = imageNode.ChildNodes[6].InnerText;
                        //        sImage.CreatedTime = imageNode.ChildNodes[7].InnerText;
                        //        sImage.UpdatedTime = imageNode.ChildNodes[8].InnerText;

                        //        sl.ServerImg = sImage;
                        //    }

                        //    //Getting Server State
                        //    XmlNodeList xnodeState = xnode.SelectNodes("//attribute[@name='state']/object");
                        //    foreach (XmlNode stateNode in xnodeState)
                        //    {
                        //        ServerState sState = new ServerState();

                        //        sState.ID = stateNode.ChildNodes[0].InnerText;
                        //        sState.Name = stateNode.ChildNodes[1].InnerText;
                        //        sState.Description = stateNode.ChildNodes[2].InnerText;

                        //        sl.State = sState;
                        //    }

                        //    //Getting Server State
                        //    XmlNodeList xnodeType = xnode.SelectNodes("//attribute[@name='state']/object");
                        //    foreach (XmlNode typeNode in xnodeType)
                        //    {
                        //        ServerType sType = new ServerType();

                        //        sType.ID = typeNode.ChildNodes[0].InnerText;
                        //        sType.Name = typeNode.ChildNodes[1].InnerText;
                        //        sType.Description = typeNode.ChildNodes[2].InnerText;

                        //        sl.ServerT = sType;
                        //    }

                        //    //Getting Server State
                        //    XmlNodeList xnodeOs = xnode.SelectNodes("//attribute[@name='state']/object");
                        //    foreach (XmlNode osNode in xnodeOs)
                        //    {
                        //        ServerOs os = new ServerOs();

                        //        os.ID = osNode.ChildNodes[0].InnerText;
                        //        os.Name = osNode.ChildNodes[1].InnerText;
                        //        os.Description = osNode.ChildNodes[2].InnerText;

                        //        sl.Os = os;
                        //   } 
                        //  }
	#endregion
                   

                        messages.Success = true;
                        sl.Message = messages;
                        ps.ServerList = sl;
                        sls.Add(ps);
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
                sl = new ServerList();
                sl.Message = messages;
                ps = new PasswordList();
                ps.ServerList = sl;
                sls.Add(ps);
            }
            return sls;
        }

    }
}
