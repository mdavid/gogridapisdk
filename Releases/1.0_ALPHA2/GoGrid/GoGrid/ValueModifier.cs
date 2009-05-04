using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class ValueModifier : IModifier
    {
        public ValueModifier(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public void Apply(Dictionary<string, string> parameters, Connection connection)
        {
            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Value)) return;
            parameters.Add(this.Name, this.Value);
        }
    }
}
