using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class Job
    {
        public Connection Connection { get; set; }

        public static Job CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            Job output = new Job();
            output.Connection = connection;

            output.ID = InternalHelper.GetAttributeElementValueFromXmlNodeAsInt32(objectElementNode, "id");
            output.Owner = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "owner");
            output.CreatedOn = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "createdon");
            output.LastUpdatedOn = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "lastupdatedon");
            output.Attempts = InternalHelper.GetAttributeElementValueFromXmlNodeAsInt32(objectElementNode, "attempts");

            XmlNode historyAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsXmlNode(objectElementNode, "history");
            XmlNodeList jobHistoryXmlNodeList = historyAttributeXmlNode.SelectNodes("list/object[@name = 'job_history']");

            List<JobHistory> jobHistoryList = new List<JobHistory>();
            foreach (XmlNode jobHistoryXmlNode in jobHistoryXmlNodeList)
            {
                JobHistory jobHistory = JobHistory.CreateFromXmlNode(jobHistoryXmlNode, connection);
                jobHistoryList.Add(jobHistory);
            }
            output.History = jobHistoryList.ToArray();

            XmlNode currentStateXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "currentstate");
            output.CurrentState = Option.CreateFromXmlNode(currentStateXmlNode, connection);

            XmlNode commandAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "command");
            output.Command = Option.CreateFromXmlNode(commandAttributeXmlNode, connection);

            XmlNode objectTypeAttributeXmlNode = InternalHelper.GetAttributeElementFromXmlNodeAsFirstChildXmlNode(objectElementNode, "objecttype");
            output.ObjectType = Option.CreateFromXmlNode(objectTypeAttributeXmlNode, connection);

            return output;
        }

        public int ID { get; set; }
        public string Owner { get; set; }
        public string CreatedOn { get; set; }
        public string LastUpdatedOn { get; set; }
        public int Attempts { get; set; }
        public JobHistory[] History { get; set; }
        public Option CurrentState { get; set; }
        public Option Command { get; set; }
        public Option ObjectType { get; set; }
    }
}
