using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class LoadBalancerPersistence : ValueModifier
    {
        public LoadBalancerPersistence(string value)
            : base("loadbalancer.persistence", value)
        {
        }

        public static LoadBalancerPersistence Default
        {
            get { return LoadBalancerPersistence.None; }
        }

        public static LoadBalancerPersistence None
        {
            get { return new LoadBalancerPersistence(string.Empty); }
        }

        public static LoadBalancerPersistence SslSticky
        {
            get { return new LoadBalancerPersistence("SSL Sticky"); }
        }

        public static LoadBalancerPersistence SourceAddress
        {
            get { return new LoadBalancerPersistence("Source Address"); }
        }
    }
}
