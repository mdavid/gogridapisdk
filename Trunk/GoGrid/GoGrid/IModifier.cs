using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public interface IModifier
    {
        void Apply(Dictionary<string, string> parameters, Connection connection);
    }
}
