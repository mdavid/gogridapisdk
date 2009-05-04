using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class Image
    {
        public Connection Connection { get; set; }

        public static Image CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            Image output = new Image();
            output.Connection = connection;

            output.ID = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableInt32(objectElementNode, "id");
            output.Name = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "name");
            output.FriendlyName = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "friendlyName");
            output.Description = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "description");
            output.Location = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "location");
            output.IsActive = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableBoolean(objectElementNode, "isActive");
            output.IsPublic = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableBoolean(objectElementNode, "isPublic");
            output.CreatedTime = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableDateTime(objectElementNode, "createdTime");
            output.UpdatedTime = InternalHelper.GetAttributeElementValueFromXmlNodeAsNullableDateTime(objectElementNode, "updatedTime");

            return output;
        }

        public int? ID { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublic { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}