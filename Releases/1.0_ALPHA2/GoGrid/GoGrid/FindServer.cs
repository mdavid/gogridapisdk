using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class FindServer : ValueModifier
    {
        public FindServer(string name, string value)
            : base(name, value)
        {
        }

        public static FindServer ByID(int id)
        {
            return new FindServer("id", id.ToString());
        }

        public static FindServer ByName(string name)
        {
            return new FindServer("name", name);
        }

        public static FindServer ByAny(string server)
        {
            return new FindServer("server", server);
        }
    }
}
