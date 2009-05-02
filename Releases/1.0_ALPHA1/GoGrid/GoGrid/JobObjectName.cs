using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class JobObjectName : ValueModifier
    {
        public JobObjectName(string value)
            : base("object", value)
        {
        }

        public static JobObjectName Any
        {
            get { return new JobObjectName(string.Empty); }
        }

        public static JobObjectName Is(string objectName)
        {
            JobObjectName name = new JobObjectName(objectName);
            return name;
        }
    }
}
