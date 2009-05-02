using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;

namespace GoGrid
{
    internal static class InternalHelper
    {
        public static string UrlEncode(this object input)
        {
            string inputAsString = input.ToString();
            string encodedInputAsString = HttpUtility.UrlEncode(inputAsString);
            return encodedInputAsString;
        }

        public static void ThrowIfLessThanZero(this int input, string paramName)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        public static void ThrowIfNull(this object input, string paramName)
        {
            if (input == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void ThrowIfNullOrEmpty(this string input, string paramName)
        {
            input.ThrowIfNull(paramName);

            if (input == string.Empty)
            {
                string message = string.Format("The parameter '{0}' cannot be an empty string!", paramName);
                throw new ArgumentException(message, paramName);
            }
        }

        public static XmlNode GetAttributeElementFromXmlNodeAsXmlNode(XmlNode objectElementNode, string name)
        {
            string xpathExpression = string.Format("attribute[@name = '{0}']", name);
            XmlNode attributeElementNode = objectElementNode.SelectSingleNode(xpathExpression);
            return attributeElementNode;
        }

        public static string GetAttributeElementValueFromXmlNodeAsString(XmlNode objectElementNode, string name)
        {
            XmlNode attributeElementNode = InternalHelper.GetAttributeElementFromXmlNodeAsXmlNode(objectElementNode, name);
            string value = attributeElementNode.InnerText;
            return value;
        }

        public static XmlNode GetAttributeElementFromXmlNodeAsFirstChildXmlNode(XmlNode objectElementNode, string name)
        {
            XmlNode attributeElementNode = InternalHelper.GetAttributeElementFromXmlNodeAsXmlNode(objectElementNode, name);
            XmlNode attributeElementFirstChildNode = attributeElementNode.ChildNodes[0];
            return attributeElementFirstChildNode;
        }

        public static int? GetAttributeElementValueFromXmlNodeAsNullableInt32(XmlNode objectElementNode, string name)
        {
            string valueAsString = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, name);

            if (string.IsNullOrEmpty(valueAsString))
            {
                return null;
            }

            int value = int.Parse(valueAsString);
            return value;
        }

        public static int GetAttributeElementValueFromXmlNodeAsInt32(XmlNode objectElementNode, string name)
        {
            int? value = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableInt32(objectElementNode, name);
            return value ?? -1;
        }

        public static decimal? GetAttributeElementValueFromXmlNodeAsNullableDecimal(XmlNode objectElementNode, string name)
        {
            string valueAsString = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, name);

            if (string.IsNullOrEmpty(valueAsString))
            {
                return null;
            }

            decimal value = decimal.Parse(valueAsString);
            return value;
        }

        public static decimal GetAttributeElementValueFromXmlNodeAsDecimal(XmlNode objectElementNode, string name)
        {
            decimal? value = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableDecimal(objectElementNode, name);
            return value ?? -1;
        }

        public static bool GetAttributeElementValueFromXmlNodeAsBoolean(XmlNode objectElementNode, string name)
        {
            string valueAsString = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, name);
            bool value = bool.Parse(valueAsString);
            return value;
        }

        public static bool? GetAttributeElementValueFromXmlNodeAsNullableBoolean(XmlNode objectElementNode, string name)
        {
            string valueAsString = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, name);

            if (string.IsNullOrEmpty(valueAsString))
            {
                return null;
            }

            bool value = bool.Parse(valueAsString);
            return value;
        }

        public static DateTime? GetAttributeElementValueFromXmlNodeAsNullableDateTime(XmlNode objectElementNode, string name)
        {
            string valueAsString = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, name);

            if (string.IsNullOrEmpty(valueAsString))
            {
                return null;
            }

            DateTime value = DateTime.Parse(valueAsString);
            return value;
        }

        public static DateTime GetAttributeElementValueFromXmlNodeAsDateTime(XmlNode objectElementNode, string name)
        {
            string valueAsString = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, name);
            DateTime value = DateTime.Parse(valueAsString);
            return value;
        }
    }
}
