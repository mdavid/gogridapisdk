using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class Lookup : ValueModifier
    {
        public Lookup(string value)
            : base("lookup", value)
        {
        }

        public static Lookup Of(string value)
        {
            return new Lookup(value);
        }

        public static Lookup All
        {
            get { return new Lookup("lookups"); }
        }

        public static Lookup IPAddressState
        {
            get { return new Lookup("ip.state"); }
        }

        public static Lookup IPAddressType
        {
            get { return new Lookup("ip.type"); }
        }

        public static Lookup JobCommand
        {
            get { return new Lookup("job.command"); }
        }

        public static Lookup JobState
        {
            get { return new Lookup("job.state"); }
        }

        public static Lookup LoadBalancerOperatingSystem
        {
            get { return new Lookup("loadbalancer.os"); }
        }

        public static Lookup LoadBalancerPersistence
        {
            get { return new Lookup("loadbalancer.persistence"); }
        }

        public static Lookup LoadBalancerState
        {
            get { return new Lookup("loadbalancer.state"); }
        }

        public static Lookup LoadBalancerType
        {
            get { return new Lookup("loadbalancer.type"); }
        }

        public static Lookup ServerOperatingSystem
        {
            get { return new Lookup("server.os"); }
        }

        public static Lookup ServerMemory
        {
            get { return new Lookup("server.ram"); }
        }

        public static Lookup ServerState
        {
            get { return new Lookup("server.state"); }
        }

        public static Lookup ServerType
        {
            get { return new Lookup("server.type"); }
        }
    }
}
