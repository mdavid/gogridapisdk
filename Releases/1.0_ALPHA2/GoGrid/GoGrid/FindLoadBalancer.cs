using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class FindLoadBalancer : ValueModifier
    {
        public FindLoadBalancer(string name, string value)
            : base(name, value)
        {
        }

        public static FindLoadBalancer ByID(int id)
        {
            return new FindLoadBalancer("id", id.ToString());
        }

        public static FindLoadBalancer ByName(string name)
        {
            return new FindLoadBalancer("name", name);
        }

        public static FindLoadBalancer ByAny(string balancer)
        {
            return new FindLoadBalancer("loadbalancer", balancer);
        }
    }
}
