using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class LoadBalancerType : ValueModifier
    {
        public LoadBalancerType(string value)
            : base("loadbalancer.type", value)
        {
        }

        public static LoadBalancerType Default
        {
            get { return LoadBalancerType.RoundRobin; }
        }

        public static LoadBalancerType RoundRobin
        {
            get { return new LoadBalancerType("Round Robin"); }
        }

        public static LoadBalancerType LeastConnect
        {
            get { return new LoadBalancerType("Least Connect"); }
        }
    }
}
