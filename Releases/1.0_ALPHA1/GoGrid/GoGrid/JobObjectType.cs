using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class JobObjectType : ValueModifier
    {
        public JobObjectType(string value) : base("job.objecttype", value)
        {
        }

        public static JobObjectType Any
        {
            get { return new JobObjectType(string.Empty); }
        }

        public static JobObjectType VirtualServer
        {
            get { return new JobObjectType("VirtualServer"); }
        }

        public static JobObjectType LoadBalancer
        {
            get { return new JobObjectType("LoadBalancer"); }
        }

        public static JobObjectType CloudStorage
        {
            get { return new JobObjectType("CloudStorage"); }
        }

        public static JobObjectType StorageDNS
        {
            get { return new JobObjectType("StorageDNS"); }
        }

    }
}
