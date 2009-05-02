using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace GoGrid
{
    public class JobHistory
    {
        public Connection Connection { get; set; }

        public static JobHistory CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            JobHistory output = new JobHistory();
            output.Connection = connection;
            
            output.ID = InternalHelper.GetAttributeElementValueFromXmlNodeAsInt32(objectElementNode, "id");
            output.Note = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "note");
            output.UpdatedOn = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "updatedon");

            XmlNode stateAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "state");
            output.State = Option.CreateFromXmlNode(stateAttributeXmlNode, connection);

            return output;
        }

        public int ID { get; set; }
        public Option State { get; set; }
        public string Note { get; set; }
        public string UpdatedOn { get; set; }
    }
}
