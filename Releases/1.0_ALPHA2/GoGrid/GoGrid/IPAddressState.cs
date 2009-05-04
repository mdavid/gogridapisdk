using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class IPAddressState : ValueModifier
    {
        public IPAddressState(string value)
            : base("ip.state", value)
        {
        }

        public static IPAddressState Assigned
        {
            get { return new IPAddressState("Assigned"); }
        }

        public static IPAddressState Unassigned
        {
            get { return new IPAddressState("Unassigned"); }
        }

        public static IPAddressState Any
        {
            get { return new IPAddressState(string.Empty); }
        }
    }
}
