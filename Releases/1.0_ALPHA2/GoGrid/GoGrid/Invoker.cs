using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography;
using System.Reflection;
using System.Net;
using System.IO;

namespace GoGrid
{
    public class Invoker
    {
        public virtual XmlDocument Invoke(string url, string apikey, string secret, string version, Dictionary<string, string> parameters)
        {
            url.ThrowIfNullOrEmpty("url");
            apikey.ThrowIfNullOrEmpty("apikey");
            secret.ThrowIfNullOrEmpty("secret");
            version.ThrowIfNullOrEmpty("version");

            string urlParameters = this.GenerateUrlParameters(apikey, secret, version, parameters);
            string completeUrl = string.Format("{0}?{1}", url, urlParameters);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(completeUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseText = reader.ReadToEnd();

            XmlDocument document = new XmlDocument();
            document.LoadXml(responseText);
            return document;
        }

        public XmlDocument Invoke(string url, string apikey, string secret, string version)
        {
            return this.Invoke(url, apikey, secret, version, null);
        }

        private string GenerateUrlParameters(string apikey, string secret, string version, Dictionary<string, string> parameters)
        {
            string signature = this.GenerateSignature(apikey, secret);

            StringBuilder parametersBuilder = new StringBuilder();
            parametersBuilder.AppendFormat("api_key={0}", apikey.UrlEncode());
            parametersBuilder.AppendFormat("&sig={0}", signature.UrlEncode());
            parametersBuilder.AppendFormat("&v={0}", version.UrlEncode());
            parametersBuilder.Append("&format=xml");

            this.AppendParametersIfNecessary(parametersBuilder, parameters);

            string urlParameters = parametersBuilder.ToString();

            return urlParameters;
        }

        private void AppendParametersIfNecessary(StringBuilder parametersBuilder, Dictionary<string, string> parameters)
        {
            if (parameters == null) return;

            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                parametersBuilder.AppendFormat("&{0}={1}", parameter.Key.UrlEncode(), parameter.Value.UrlEncode());
            }
        }

        private string GenerateSignature(string apikey, string secret)
        {
            int timeSinceEpochInSeconds = this.GetTotalSecondsSinceUnixEpoch();

            string hashInput = string.Format("{0}{1}{2}", apikey, secret, timeSinceEpochInSeconds);
            byte[] hashInputInBytes = Encoding.ASCII.GetBytes(hashInput);

            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] hashOutputInBytes = provider.ComputeHash(hashInputInBytes);
            string hashOutput = this.ConvertHashOutputToHexString(hashOutputInBytes);

            return hashOutput;
        }

        private string ConvertHashOutputToHexString(byte[] hashOutputInBytes)
        {
            StringBuilder hexBuilder = new StringBuilder();

            foreach (byte hashOutputByte in hashOutputInBytes)
            {
                hexBuilder.AppendFormat("{0:x2}", hashOutputByte);
            }

            string hashOutput = hexBuilder.ToString();

            return hashOutput;
        }

        private int GetTotalSecondsSinceUnixEpoch()
        {
            DateTime epoch = new DateTime(1970, 1, 1);
            TimeSpan timeSinceEpoch = DateTime.UtcNow - epoch;
            int timeSinceEpochInSeconds = (int)timeSinceEpoch.TotalSeconds;
            return timeSinceEpochInSeconds;
        }
    }
}
