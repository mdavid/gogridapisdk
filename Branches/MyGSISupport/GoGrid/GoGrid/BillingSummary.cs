using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class BillingSummary
    {
        public Connection Connection { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal MemoryAllotment { get; set; }
        public decimal MemoryInUse { get; set; }
        public decimal MemoryAccrued { get; set; }
        public decimal MemoryOverage { get; set; }
        public decimal MemoryOverageCharge { get; set; }
        public decimal TransferAllotment { get; set; }
        public decimal TransferAccrued { get; set; }
        public decimal TransferOverage { get; set; }
        public decimal TransferOverageCharge { get; set; }

        public static BillingSummary CreateFromXmlNode(XmlNode objectElementNode, Connection connection)
        {
            BillingSummary output = new BillingSummary();
            output.Connection = connection;

            output.StartDate = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "startDate");
            output.EndDate = InternalHelper.GetAttributeElementValueFromXmlNodeAsString(objectElementNode, "endDate");
            output.MemoryAllotment = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "memoryAllotment");
            output.MemoryInUse = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "memoryInUse");
            output.MemoryAccrued = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "memoryAccrued");
            output.MemoryOverage = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "memoryOverage");
            output.MemoryOverageCharge = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "memoryOverageCharge");
            output.TransferAllotment = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "transferAllotment");
            output.TransferAccrued = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "transferAccrued");
            output.TransferOverage = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "transferOverage");
            output.TransferOverageCharge = InternalHelper.GetAttributeElementValueFromXmlNodeAsDecimal(objectElementNode, "transferOverageCharge");

            return output;
        }
    }
}