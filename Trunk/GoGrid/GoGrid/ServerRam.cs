using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class ServerMemory : ValueModifier
    {
        public ServerMemory(string value) : base("server.ram", value)
        {
        }

        public static ServerMemory GB1
        {
            get { return new ServerMemory("1GB"); }
        }

        public static ServerMemory GB2
        {
            get { return new ServerMemory("2GB"); }
        }

        public static ServerMemory GB4
        {
            get { return new ServerMemory("4GB"); }
        }

        public static ServerMemory GB8
        {
            get { return new ServerMemory("8GB"); }
        }

        public static ServerMemory MB512
        {
            get { return new ServerMemory("512MB"); }
        }
    }
}
