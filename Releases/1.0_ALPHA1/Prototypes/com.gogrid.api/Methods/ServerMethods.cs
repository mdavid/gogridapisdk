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
    public class ServerMethods
    {       
        public static List<ServerList> Add_Server(
            string name, 
            string img, 
            string ram, 
            string ip, 
            string description)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_add);
            
            url += "&name=" + name +
                "&image=" + img +
                "&ram=" + ram +
                "&ip=" + ip +
                "&description=" +description;

            List<ServerList> sls = CallingGrid(url);


            //return response;
            return sls;


        }

        public static List<ServerList> Add_Server(System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_add);
            
            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + HttpUtility.UrlEncode(d.Value.ToString());
                }
            }
            
            List<ServerList> sls = CallingGrid(url);


            //return response;
            return sls;
        }

        public static List<ServerList> Get_Server_List()
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_list);


            List<ServerList> sls = CallingGrid(url);
            //return response;
            return sls;
        }

        public static List<ServerList> Get_Server_List(System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_list);

            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + HttpUtility.UrlEncode(d.Value.ToString());
                }
            }
            

            List<ServerList> sls = CallingGrid(url);
            //return response;
            return sls;
        }
        
        public static List<ServerList> Get_Server_List_ByServerType(string serverType)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_list);
            url += "&server.type=" + serverType;

            List<ServerList> sls = CallingGrid(url);
            //return response;
            return sls;
        }
        
        public static List<ServerList> Get_Server_ByID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_get);
            url += "&id=" + id;


            List<ServerList> sls = CallingGrid(url);


            //return response;
            return sls;
        }
        
        public static List<ServerList> Get_Server_ByName(string name)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_get);
            url += "&name=" + name;
            List<ServerList> sls = CallingGrid(url);


            //return response;
            return sls;
        }
        
        public static List<ServerList> Get_Server_ByName(string[] names)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_get);
            url += GetMulitpleNames(names);

            List<ServerList> sls = CallingGrid(url);


            //return response;
            return sls;
        }

        public static List<ServerList> Delete_Server_ByID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_delete);
            url += "&id=" + id;

            List<ServerList> sls = CallingGrid(url);

            //return response;
            return sls;

        }
        
        public static List<ServerList> Delete_Server_ByName(string name)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_delete);
            url += "&name=" + name;

            List<ServerList> sls = CallingGrid(url);

            //return response;
            return sls;

        }

        //Helper Function
        private static string GetMulitpleNames(string[] names)
        {
            string nameformat = string.Empty;

            foreach (string s in names)
            {
                nameformat += "&name=" + s;
            }

            return nameformat;
        }

        //Power Methods

        public static List<ServerList> Power(System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_power);

            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + HttpUtility.UrlEncode(d.Value.ToString());
                }
            }

            List<ServerList> sls = CallingGrid(url);


            //return response;
            return sls;
        }

        public static List<ServerList> Power_Start_Server_ByID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_power);
            url += "&id=" + id +
                "&power=start";

            List<ServerList> sls = CallingGrid(url);


            //return response;
            return sls;
        }

        public static List<ServerList> Power_Start_Server_ByName(string name)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_power);
            url += "&name=" + name +
                "&power=start";


            List<ServerList> sls = CallingGrid(url);

            //return response;
            return sls;
        }

        public static List<ServerList> Power_Stop_Server_ByID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_power);
            url += "&id=" + id +
                "&power=stop";

        
            List<ServerList> sls = CallingGrid(url);

            //return response;
            return sls;
        }

        public static List<ServerList> Power_Stop_Server_ByName(string name)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_power);
            url += "&name=" + name +
                "&power=stop";

            List<ServerList> sls = CallingGrid(url);

            //return response;
            return sls;
        }

        public static List<ServerList> Power_Reboot_Server_ByID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_power);
            url += "&id=" + id +
                "&power=cycle";

            List<ServerList> sls = CallingGrid(url);

            //return response;
            return sls;
        }

        public static List<ServerList> Power_Reboot_Server_ByName(string name)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_server_power);
            url += "&name=" + name +
                "&power=cycle";


            List<ServerList> sls = CallingGrid(url);
            //return response;
            return sls;
        }
        
        private static List<ServerList> CallingGrid(string url)
        {
            Messages messages = new Messages();
            ServerList sl;

            List<ServerList> sls = new List<ServerList>();
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
                    

                    XmlNodeList Xn = ss.SelectNodes("//object[@name='server']");

                    foreach (XmlNode xnode in Xn)
                    {


                        sl = new ServerList();

                        sl.ID = xnode.ChildNodes[0].InnerText;
                        sl.Name = xnode.ChildNodes[1].InnerText;
                        sl.Description = xnode.ChildNodes[2].InnerText;

                        //Getting IP Information
                        XmlNodeList xnodeip = xnode.SelectNodes("//attribute[@name='ip']/object");
                        foreach (XmlNode ipNode in xnodeip)
                        {
                            Ip ipNew = new Ip();
                            ipNew.ID = ipNode.ChildNodes[0].InnerText;
                            ipNew.IP = ipNode.ChildNodes[1].InnerText;
                            ipNew.Subnet = ipNode.ChildNodes[2].InnerText;
                            ipNew.Public = ipNode.ChildNodes[3].InnerText;
                            sl.ServerIP = ipNew;
                        }

                        //Getting the Ram Information
                        XmlNodeList xnoderam = xnode.SelectNodes("//attribute[@name='ram']/object");
                        foreach (XmlNode ramNode in xnoderam)
                        {
                            Ram ramNew = new Ram();

                            ramNew.ID = ramNode.ChildNodes[0].InnerText;
                            ramNew.Name = ramNode.ChildNodes[1].InnerText;
                            ramNew.Description = ramNode.ChildNodes[2].InnerText;
                            sl.ServerRam = ramNew;
                        }

                        //Getting Server Image Information
                        XmlNodeList xnodeImage = xnode.SelectNodes("//attribute[@name='image']/object");
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

                            sl.ServerImg = sImage;
                        }

                        //Getting Server State
                        XmlNodeList xnodeState = xnode.SelectNodes("//attribute[@name='state']/object");
                        foreach (XmlNode stateNode in xnodeState)
                        {
                            ServerState sState = new ServerState();

                            sState.ID = stateNode.ChildNodes[0].InnerText;
                            sState.Name = stateNode.ChildNodes[1].InnerText;
                            sState.Description = stateNode.ChildNodes[2].InnerText;

                            sl.State = sState;
                        }

                        //Getting Server State
                        XmlNodeList xnodeType = xnode.SelectNodes("//attribute[@name='type']/object");
                        foreach (XmlNode typeNode in xnodeType)
                        {
                            ServerType sType = new ServerType();

                            sType.ID = typeNode.ChildNodes[0].InnerText;
                            sType.Name = typeNode.ChildNodes[1].InnerText;
                            sType.Description = typeNode.ChildNodes[2].InnerText;

                            sl.ServerT = sType;
                        }

                        //Getting Server State
                        XmlNodeList xnodeOs = xnode.SelectNodes("//attribute[@name='os']/object");
                        foreach (XmlNode osNode in xnodeOs)
                        {
                            ServerOs os = new ServerOs();

                            os.ID = osNode.ChildNodes[0].InnerText;
                            os.Name = osNode.ChildNodes[1].InnerText;
                            os.Description = osNode.ChildNodes[2].InnerText;

                            sl.Os = os;
                        }

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
                

                messages.Error_400 = response.Contains("400") == true ? response.ToString() : "";
                messages.Error_401 = response.Contains("401") == true ? response.ToString() : "";
                messages.Error_403 = response.Contains("403") == true ? response.ToString() : "";
                messages.Error_404 = response.Contains("404") == true ? response.ToString() : "";
                messages.Error_500 = response.Contains("500") == true ? response.ToString() : "";
                messages.Success = false;
                sl = new ServerList();
                sl.Message = messages;
                sls.Add(sl);
            }
            return sls;
        }

    }
}
