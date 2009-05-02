using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace com.gogrid.api
{
    public class GlobalVariables
    {
        #region Load Balancer call methods urls
        // Load Balancer call methods urls
        public static string grid_loadbalancer_list = "grid/loadbalancer/list";
        public static string grid_loadbalancer_get = "grid/loadbalancer/get";
        public static string grid_laodbalancer_add = "grid/loadbalancer/add";
        public static string grid_loadbalancer_delete = "grid/loadbalancer/delete"; 
        #endregion

        #region Server Methods call methods urls
        // Server Methods call methods urls
        public static string grid_server_list = "grid/server/list";
        public static string grid_server_get = "grid/server/get";
        public static string grid_server_add = "grid/server/add";
        public static string grid_server_delete = "grid/server/delete";
        public static string grid_server_power = "grid/server/power"; 
        #endregion

        #region Server Image Methods Url
        // Server Image Methods Url
        public static string grid_image_list = "grid/image/list"; 
        #endregion

        #region IP Methods Url
        // IP Methods Url
        public static string grid_ip_list = "grid/ip/list"; 
        #endregion

        #region Passwords Methods
        // Passwords Methods
        public static string support_password_list = "support/password/list";
        public static string support_password_get = "support/password/get"; 
        #endregion

        #region Billing Methods
        // Billing Methods
        public static string myaccount_billing_get = "myaccount/billing/get"; 
        #endregion

        #region Utility Methods
        //Utility Methods
        public static string common_lookup_list = "common/lookup/list"; 
        #endregion

        private static string _v = "1.0";

        public static string V { 
            get
            {
                return _v;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _v = value;
                }
               
            }
        }
        
        public static string GetUrl(string method)
        {
            string url = GridCredentials.CC_API + method +
                "?api_key=" + GridCredentials.CC_KEY +
                "&v="+ GlobalVariables.V + 
                "&sig=" + GlobalVariables.getSignature(GridCredentials.CC_KEY, GridCredentials.CC_SECRET) +
                "&format=xml";
            return url;
        }

        #region Certification for Secret
        protected static string MD5(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }


        // Generate the request signature
        public static string getSignature(string _api_key, string _secret)
        {
            int epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            return MD5(_api_key + _secret + epoch);
        }
        protected class MyCertificatePolicy : ICertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint srvp, X509Certificate cert, WebRequest req, int problem)
            {
                return true;
            }
        }
        #endregion
    }
}
