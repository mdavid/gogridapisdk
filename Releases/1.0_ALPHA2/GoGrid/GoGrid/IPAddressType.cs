using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class IPAddressType : ValueModifier
    {
        public IPAddressType(string value)
            : base("ip.type", value)
        {
        }

        public static IPAddressType Public
        {
            get { return new IPAddressType("Public"); }
        }

        public static IPAddressType Public2
        {
            get { return new IPAddressType("Public 2"); }
        }

        public static IPAddressType Public3
        {
            get { return new IPAddressType("Public 3"); }
        }

        public static IPAddressType Private
        {
            get { return new IPAddressType("Private"); }
        }

        public static IPAddressType Private2
        {
            get { return new IPAddressType("Private2"); }
        }

        public static IPAddressType Any
        {
            get { return new IPAddressType(string.Empty); }
        }
    }
}
