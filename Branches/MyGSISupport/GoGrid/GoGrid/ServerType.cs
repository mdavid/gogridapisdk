using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class ServerType : ValueModifier
    {
        public ServerType(string value)
            : base("server.type", value)
        {
        }

        public static ServerType Any
        {
            get { return new ServerType(string.Empty); }
        }

        public static ServerType WebServer
        {
            get { return new ServerType("Web Server"); }
        }

        public static ServerType DatabaseServer
        {
            get { return new ServerType("Database Server"); }
        }
    }
}
