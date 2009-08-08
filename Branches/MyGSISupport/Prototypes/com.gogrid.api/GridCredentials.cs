using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Net;
//using System.Windows.Forms;
using System.Web;
//using System.Web.Configuration;

namespace com.gogrid.api
{
    public static class GridCredentials
    {
        //public static string _CC_API = "https://api.gogrid.com/api/";
        //public static string CC_KEY = "7241c73a5ba8255e";
        //public static string CC_SECRET = "webhungogrid";

        private static string _CC_API = String.Empty;
        private static string _CC_KEY = String.Empty;
        private static string _CC_SECRET = String.Empty;

        public static string CC_API
        {
            get 
            {
                if (!String.IsNullOrEmpty(_CC_API))
                {
                    return _CC_API;
                }
                else
                {
                    if (ConfigurationManager.AppSettings["CC_API"] != null || ConfigurationManager.AppSettings["CC_API"] != "")
                        _CC_API = ConfigurationManager.AppSettings["CC_API"].ToString();

                    return _CC_API;
                }
                
            }
            set
            {
                if (ConfigurationManager.AppSettings["CC_API"] != null || ConfigurationManager.AppSettings["CC_API"] != "")
                    _CC_API = ConfigurationManager.AppSettings["CC_API"];
                if (!String.IsNullOrEmpty(value))
                    _CC_API = value;
                
            }

        }

        public static string CC_KEY
        {
            get
            {
                if (!string.IsNullOrEmpty(_CC_KEY))
                {
                    
                    return _CC_KEY;
                }
                else
                {
                    if (ConfigurationManager.AppSettings["CC_KEY"] != null || ConfigurationManager.AppSettings["CC_KEY"] != "")
                        _CC_KEY = ConfigurationManager.AppSettings["CC_KEY"].ToString();
                    return _CC_KEY;
                }
            }
            set
            {
                if (ConfigurationManager.AppSettings["CC_KEY"] != null || ConfigurationManager.AppSettings["CC_API"] != "")
                    _CC_KEY = ConfigurationManager.AppSettings["CC_KEY"];

                if (!String.IsNullOrEmpty(value))
                    _CC_KEY = value;
            }
        }

        public static string CC_SECRET
        {
            get
            {
                if (!String.IsNullOrEmpty(_CC_SECRET))
                {
                    return _CC_SECRET;
                }
                else
                {
                    if (ConfigurationManager.AppSettings["CC_SECRET"] != null || ConfigurationManager.AppSettings["CC_SECRET"] != "")
                        _CC_SECRET = ConfigurationManager.AppSettings["CC_SECRET"].ToString();

                    return _CC_SECRET;
                }
            }
            set
            {
                if (ConfigurationManager.AppSettings["CC_API"] != null || ConfigurationManager.AppSettings["CC_API"] != "")
                    _CC_SECRET = ConfigurationManager.AppSettings["CC_SECRET"];

                if (!String.IsNullOrEmpty(value))
                    _CC_SECRET = value;
            }
        }
    }
}
