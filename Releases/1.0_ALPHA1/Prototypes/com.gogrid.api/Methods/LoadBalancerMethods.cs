using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml;
using System.IO;
using System.Web;

namespace com.gogrid.api
{
    public class LoadBalancerMethods
    {
        public static List<LoadBalancer> Get_LoadBalancer_List(string method, Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(method);

            if (_params != null)
            {
                foreach (DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + d.Value;
                }
            }

            return CallingGrid(url);
        }

        public static List<LoadBalancer> Get_LoadBalancer_List(Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_loadbalancer_get);

            if (_params != null)
            {
                foreach (DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + d.Value;
                }
            }

            return CallingGrid(url);
        }

        public static List<LoadBalancer> Get_LoadBalancer_List()
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_loadbalancer_list);

            return CallingGrid(url);
        }

        public static List<LoadBalancer> Get_LoadBalancer_ByID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_loadbalancer_get);
            url += "&id=" + id;

            return CallingGrid(url);
        }

        public static List<LoadBalancer> Get_LoadBalancer_ByName(string name)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_loadbalancer_get);
            url += "&name=" + name;

            return CallingGrid(url);
        }

        public static List<LoadBalancer> Add_LoadBalancer(System.Collections.Hashtable _params)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_laodbalancer_add);

            if (_params != null)
            {
                foreach (System.Collections.DictionaryEntry d in _params)
                {
                    url += "&" + d.Key + "=" + HttpUtility.UrlEncode(d.Value.ToString());
                }
            }

            return CallingGrid(url);
            
        }

        public static List<LoadBalancer> Delete_LoadBalancer_ByID(string id)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_loadbalancer_delete);
            url += "&id=" + id;

            return CallingGrid(url);
        }

        public static List<LoadBalancer> Delete_LoadBalancer_ByName(string name)
        {
            // Start constructing the request URL, starting with the server and method
            string url = GlobalVariables.GetUrl(GlobalVariables.grid_loadbalancer_delete);
            url += "&name=" + name;

            return CallingGrid(url);
        }

        
        // Calling The Grid Function
        private static List<LoadBalancer> CallingGrid(string url)
        {
            Messages messages = new Messages();
            LoadBalancer ps;
            
            List<LoadBalancer> sls = new List<LoadBalancer>();
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
                    //XDocument myList = XDocument.Load(response);

                    if (response.Contains("success"))
                    {
                        messages.Success = true;
                    }

                    XmlNodeList Xn = ss.SelectNodes("//object[@name='loadbalancer']");

                    foreach (XmlNode xnode in Xn)
                    {

                        ps = new LoadBalancer();

                        ps.ID = xnode.ChildNodes[0].InnerText;
                        ps.Name = xnode.ChildNodes[1].InnerText;
                        ps.Description = xnode.ChildNodes[2].InnerText;

                        #region VirtualIp List

                        XmlNodeList xvirtualIp = xnode.SelectNodes("//attribute[@name='virtualip']/object[@name='ipportpair']");

                        foreach (XmlNode xvIP in xvirtualIp)
                        {
                            Ip virIp = new Ip();

                            virIp.Port = xvIP.ChildNodes[1].InnerText;
                            XmlNodeList ip = xnode.SelectNodes("//attribute[@name='virtualip']/object[@name='ipportpair']/attribute[@name='ip']/object[@name='ip']");

                            foreach (XmlNode xip in ip)
                            {
                                virIp.ID = xip.ChildNodes[0].InnerText;
                                virIp.IP = xip.ChildNodes[1].InnerText;
                                virIp.Subnet = xip.ChildNodes[2].InnerText;
                                virIp.Public = xip.ChildNodes[3].InnerText;
                            }
                            ps.IP = virIp;
                        } 
                        #endregion

                        #region Getting The Type

                        XmlNodeList xType = xnode.SelectNodes("//attribute[@name='type']/object[@name='option']");

                        foreach (XmlNode typeOption in xType)
                        {
                            ServerType type = new ServerType();

                            type.ID = typeOption.ChildNodes[0].InnerText;
                            type.Name = typeOption.ChildNodes[1].InnerText;
                            type.Description = typeOption.ChildNodes[2].InnerText;

                            ps.Load_Balancer_Type = type;
                        }

                        #endregion

                        #region Getting the Persistence Info
                        XmlNodeList xPersistence = xnode.SelectNodes("//attribute[@name='persistence']/object[@name='option']");

                        foreach (XmlNode typeOption in xPersistence)
                        {
                            Persistence type = new Persistence();

                            type.ID = typeOption.ChildNodes[0].InnerText;
                            type.Name = typeOption.ChildNodes[1].InnerText;
                            type.Description = typeOption.ChildNodes[2].InnerText;

                            ps.Persistences = type;
                        }
                        

                        #endregion
                        #region Real IP List Information

                        XmlNodeList xrealIp = xnode.SelectNodes("//attribute[@name='realiplist']/object[@name='ipportpair']");

                        foreach (XmlNode xvIP in xvirtualIp)
                        {
                            Ip virIp = new Ip();

                            virIp.Port = xvIP.ChildNodes[0].InnerText;
                            XmlNodeList ip = xnode.SelectNodes("//attribute[@name='virtualip']/object[@name='ipportpair']/attribute[@name='ip']/object[@name='ip']");

                            foreach (XmlNode xip in ip)
                            {
                                virIp.ID = xip.ChildNodes[0].InnerText;
                                virIp.IP = xip.ChildNodes[1].InnerText;
                                virIp.Subnet = xip.ChildNodes[2].InnerText;
                                virIp.Public = xip.ChildNodes[3].InnerText;
                            }
                            ps.RealIpList = virIp;
                        }
                        #endregion

                        #region Getting the OS information

                        XmlNodeList xnodeOs = xnode.SelectNodes("//attribute[@name='os']/object[@name='option']");
                        foreach (XmlNode osNode in xnodeOs)
                        {
                            ServerOs os = new ServerOs();

                            os.ID = osNode.ChildNodes[0].InnerText;
                            os.Name = osNode.ChildNodes[1].InnerText;
                            os.Description = osNode.ChildNodes[2].InnerText;

                            ps.OS = os;
                        } 

                        #endregion

                        #region Getting the State information

                        XmlNodeList xstate = xnode.SelectNodes("//attribute[@name='state']/object[@name='option']");
                        foreach (XmlNode osNode in xstate)
                        {
                            ServerState state = new ServerState();

                            state.ID = osNode.ChildNodes[0].InnerText;
                            state.Name = osNode.ChildNodes[1].InnerText;
                            state.Description = osNode.ChildNodes[2].InnerText;

                            ps.State = state;
                        }

                        #endregion


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


                        ps.Message = messages;
                        
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
                ps = new LoadBalancer();
                ps.Message = messages;
                
                sls.Add(ps);
            }
            return sls;
        }
    }
}
