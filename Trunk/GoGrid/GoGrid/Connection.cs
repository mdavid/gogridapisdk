using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GoGrid
{
    public class Connection
    {
        public Connection(string apikey, string secret)
        {
            apikey.ThrowIfNullOrEmpty("apikey");
            this.Apikey = apikey;

            secret.ThrowIfNullOrEmpty("secret");
            this.Secret = secret;

            this.Invoker = new Invoker();
        }

        public Connection(string apikey, string secret, Invoker invoker) : this(apikey, secret)
        {
            invoker.ThrowIfNull("invoker");
            this.Invoker = invoker;
        }

        public string Apikey { get; set; }
        public string Secret { get; set; }
        public Invoker Invoker { get; set; }

        private Response GetResponse(string url, Dictionary<string, string> parameters)
        {
            XmlDocument responseDocument = this.Invoker.Invoke(
                url,
                this.Apikey,
                this.Secret,
                "1.0",
                parameters
                );

            Response response = new Response(responseDocument);
            return response;
        }

        internal Response GetResponse(string url, IModifier[] modifiers)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            foreach (IModifier modifier in modifiers)
            {
                modifier.Apply(parameters, this);
            }

            Response response = this.GetResponse(url, parameters);
            return response;
        }

        public List<Image> ListImages()
        {
            return this.ListImages(Paging.None);
        }

        public List<Image> ListImages(int pageSize, int pageIndex)
        {
            return this.ListImages(
                Paging.Of(pageSize, pageIndex)
                );
        }

        public List<Image> ListImages(Paging paging)
        {
            IModifier[] modifiers = new IModifier[] { paging };

            Response response = this.GetResponse(MethodConstants.GridImageList, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.ServerImage);

            List<Image> collection = new List<Image>();
            foreach (XmlNode node in list)
            {
                Image image = Image.CreateFromXmlNode(node, this);
                collection.Add(image);
            }

            return collection;
        }

        public List<Job> ListJobs()
        {
            return this.ListJobs(DateRange.None, JobObjectType.Any, JobState.Any, Owner.Any, JobObjectName.Any, Paging.None);
        }

        public List<Job> ListJobs(DateTimeOffset from, DateTimeOffset to)
        {
            return this.ListJobs(
                DateRange.Between(from, to),
                JobObjectType.Any,
                JobState.Any,
                Owner.Any,
                JobObjectName.Any,
                Paging.None
                );
        }

        public List<Job> ListJobs(int pageSize, int pageIndex)
        {
            return this.ListJobs(
                DateRange.None,
                JobObjectType.Any,
                JobState.Any,
                Owner.Any,
                JobObjectName.Any,
                Paging.Of(pageSize, pageIndex)
                );
        }

        public List<Job> ListJobs(DateRange range, JobObjectType objectType, JobState state, Owner owner, JobObjectName name, Paging paging)
        {
            IModifier[] modifiers = new IModifier[] { range, objectType, state, owner, name, paging };

            Response response = this.GetResponse(MethodConstants.GridJobList, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Job);

            List<Job> collection = new List<Job>();
            foreach (XmlNode node in list)
            {
                Job job = Job.CreateFromXmlNode(node, this);
                collection.Add(job);
            }

            return collection;
        }

        public LoadBalancer GetLoadBalancer(string balancer)
        {
            return this.GetLoadBalancer(FindLoadBalancer.ByAny(balancer));
        }

        public LoadBalancer GetLoadBalancer(FindLoadBalancer findBy)
        {
            Response response = this.GetResponse(MethodConstants.GridLoadBalancerGet, new IModifier[] { findBy });
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.LoadBalancer);
            LoadBalancer balancer = LoadBalancer.CreateFromXmlNode(list[0], this);
            return balancer;
        }

        public Server GetServer(string server)
        {
            return this.GetServer(FindServer.ByAny(server));
        }

        public Server GetServer(FindServer findBy)
        {
            Response response = this.GetResponse(MethodConstants.GridServerGet, new IModifier[] { findBy });
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Server);
            Server server = Server.CreateFromXmlNode(list[0], this);
            return server;
        }

        public Job GetJob(int id)
        {
            ValueModifier idModifier = new ValueModifier("id", id.ToString());
            Response response = this.GetResponse(MethodConstants.GridJobGet, new IModifier[] { idModifier });
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Job);
            Job job = Job.CreateFromXmlNode(list[0], this);
            return job;
        }

        public List<LoadBalancer> ListLoadBalancers()
        {
            return this.ListLoadBalancers(Paging.None);
        }

        public List<LoadBalancer> ListLoadBalancers(int pageSize, int pageIndex)
        {
            return this.ListLoadBalancers(Paging.Of(pageSize, pageIndex));
        }

        public List<LoadBalancer> ListLoadBalancers(Paging paging)
        {
            IModifier[] modifiers = new IModifier[] { paging };

            Response response = this.GetResponse(MethodConstants.GridLoadBalancerList, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.LoadBalancer);

            List<LoadBalancer> collection = new List<LoadBalancer>();
            foreach (XmlNode node in list)
            {
                LoadBalancer loadBalancer = LoadBalancer.CreateFromXmlNode(node, this);
                collection.Add(loadBalancer);
            }

            return collection;
        }

        public List<Server> ListServers()
        {
            return this.ListServers(ServerType.Any, Paging.None);
        }

        public List<Server> ListServers(int pageSize, int pageIndex)
        {
            return this.ListServers(ServerType.Any, Paging.Of(pageSize, pageIndex));
        }

        public List<Server> ListServers(ServerType serverType, Paging paging)
        {
            IModifier[] modifiers = new IModifier[] { serverType, paging };

            Response response = this.GetResponse(MethodConstants.GridServerList, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Server);

            List<Server> collection = new List<Server>();
            foreach (XmlNode node in list)
            {
                Server server = Server.CreateFromXmlNode(node, this);
                collection.Add(server);
            }

            return collection;
        }

        public List<IPAddress> ListIPAddresses()
        {
            return this.ListIPAddresses(
                IPAddressState.Any,
                IPAddressType.Any,
                Paging.None
                );
        }

        public List<IPAddress> ListIPAddresses(int pageSize, int pageIndex)
        {
            return this.ListIPAddresses(
                IPAddressState.Any,
                IPAddressType.Any,
                Paging.Of(pageSize, pageIndex)
                );
        }

        public List<IPAddress> ListIPAddresses(IPAddressState addressState, IPAddressType addressType, Paging paging)
        {
            IModifier[] modifiers = new IModifier[] { addressState, addressType, paging };

            Response response = this.GetResponse(MethodConstants.GridIPAddressList, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.IPAddress);

            List<IPAddress> collection = new List<IPAddress>();
            foreach (XmlNode node in list)
            {
                IPAddress address = IPAddress.CreateFromXmlNode(node, this);
                collection.Add(address);
            }

            return collection;
        }

        public List<ServerPassword> ListServerPasswords()
        {
            return this.ListServerPasswords(Paging.None);
        }

        public List<ServerPassword> ListServerPasswords(int pageSize, int pageIndex)
        {
            return this.ListServerPasswords(Paging.Of(pageSize, pageIndex));
        }

        public List<ServerPassword> ListServerPasswords(Paging paging)
        {
            IModifier[] modifiers = new IModifier[] { paging };

            Response response = this.GetResponse(MethodConstants.SupportPasswordList, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.ServerPassword);

            List<ServerPassword> collection = new List<ServerPassword>();
            foreach (XmlNode node in list)
            {
                ServerPassword password = ServerPassword.CreateFromXmlNode(node, this);
                collection.Add(password);
            }

            return collection;
        }

        public List<Option> ListOptions(string lookup)
        {
            return this.ListOptions(lookup, OptionSort.None, Paging.None);
        }

        public List<Option> ListOptions(string lookup, int pageSize, int pageIndex)
        {
            return this.ListOptions(lookup, OptionSort.None, Paging.Of(pageSize, pageIndex));
        }

        public List<Option> ListOptions(string lookup, OptionSort sort, Paging paging)
        {
            return this.ListOptions(Lookup.Of(lookup), sort, paging);
        }

        public List<Option> ListOptions(Lookup lookup, OptionSort sort, Paging paging)
        {
            IModifier[] modifiers = new IModifier[] { lookup, sort, paging };

            Response response = this.GetResponse(MethodConstants.CommonLookupList, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Option);

            List<Option> collection = new List<Option>();
            foreach (XmlNode node in list)
            {
                Option option = Option.CreateFromXmlNode(node, this);
                collection.Add(option);
            }

            return collection;
        }

        public Server AddServer(string name, string image, string memory, string address)
        {
            return this.AddServer(name, image, memory, address, string.Empty);
        }

        public Server AddServer(string name, string image, string memory, string address, string description)
        {
            IModifier[] modifiers = new IModifier[]
            {
                new ValueModifier("name", name),
                new ValueModifier("image", image),
                new ValueModifier("server.ram", memory),
                new ValueModifier("ip", address),
                new ValueModifier("description", description)
            };

            Response response = this.GetResponse(MethodConstants.GridServerAdd, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Server);
            Server server = Server.CreateFromXmlNode(list[0], this);

            return server;
        }

        public Server StartServer(string server)
        {
            return this.StartServer(FindServer.ByAny(server));
        }

        public Server StartServer(FindServer findBy)
        {
            ValueModifier power = new ValueModifier("power", "start");
            IModifier[] modifiers = new IModifier[] { findBy, power };

            Response response = this.GetResponse(MethodConstants.GridServerPower, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Server);
            Server server = Server.CreateFromXmlNode(list[0], this);

            return server;
        }

        public Server StopServer(string server)
        {
            return this.StopServer(FindServer.ByAny(server));
        }

        public Server StopServer(FindServer findBy)
        {
            ValueModifier power = new ValueModifier("power", "stop");
            IModifier[] modifiers = new IModifier[] { findBy, power };

            Response response = this.GetResponse(MethodConstants.GridServerPower, modifiers);
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Server);
            Server server = Server.CreateFromXmlNode(list[0], this);

            return server;
        }

        public Server DeleteServer(string server)
        {
            return this.DeleteServer(FindServer.ByAny(server));
        }

        public Server DeleteServer(FindServer findBy)
        {
            Response response = this.GetResponse(MethodConstants.GridServerDelete, new IModifier[] { findBy });
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.Server);
            Server server = Server.CreateFromXmlNode(list[0], this);
            return server;
        }

        public LoadBalancer DeleteLoadBalancer(string balancer)
        {
            return this.DeleteLoadBalancer(FindLoadBalancer.ByAny(balancer));
        }

        public LoadBalancer DeleteLoadBalancer(FindLoadBalancer findBy)
        {
            Response response = this.GetResponse(MethodConstants.GridLoadBalancerDelete, new IModifier[] { findBy });
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.LoadBalancer);
            LoadBalancer balancer = LoadBalancer.CreateFromXmlNode(list[0], this);
            return balancer;
        }

        public LoadBalancer AddLoadBalancer(string name, LoadBalancerInterface virtualInterface, LoadBalancerInterface[] realInterfaces, LoadBalancerType balancerType, LoadBalancerPersistence balancerPersistence)
        {
            return this.AddLoadBalancer(name, virtualInterface, realInterfaces, balancerType, balancerPersistence, string.Empty);
        }

        public LoadBalancer AddLoadBalancer(string name, LoadBalancerInterface virtualInterface, LoadBalancerInterface[] realInterfaces, LoadBalancerType balancerType, LoadBalancerPersistence balancerPersistence, string description)
        {
            List<IModifier> modifiers = new List<IModifier>();

            ValueModifier nameModifier = new ValueModifier("name", name);
            modifiers.Add(nameModifier);

            ValueModifier descriptionModifier = new ValueModifier("description", description);
            modifiers.Add(descriptionModifier);

            ValueModifier virtualInterfaceAddressModifier = new ValueModifier("virtualip.ip", virtualInterface.Address.Address);
            modifiers.Add(virtualInterfaceAddressModifier);

            ValueModifier virtualInterfacePortModifier = new ValueModifier("virtualip.port", virtualInterface.Port.ToString());
            modifiers.Add(virtualInterfacePortModifier);

            for (int index = 0; index < realInterfaces.Length; index++)
            {
                string realInterfaceAddressParameterName = string.Format("realiplist.{0}.ip", index);
                ValueModifier realInterfaceAddressModifier = new ValueModifier(realInterfaceAddressParameterName, realInterfaces[0].Address.Address);
                modifiers.Add(realInterfaceAddressModifier);

                string realInterfacePortParameterName = string.Format("realiplist.{0}.port", index);
                ValueModifier realInterfacePortModifier = new ValueModifier(realInterfacePortParameterName, realInterfaces[index].Port.ToString());
                modifiers.Add(realInterfacePortModifier);
            }

            modifiers.Add(balancerPersistence);
            modifiers.Add(balancerType);

            Response response = this.GetResponse(MethodConstants.GridLoadBalancerAdd, modifiers.ToArray());
            XmlNodeList list = response.GetObjectNodes(ObjectConstants.LoadBalancer);
            LoadBalancer balancer = LoadBalancer.CreateFromXmlNode(list[0], this);

            return balancer;
        }

    }
}
