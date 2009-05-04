using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class Owner : IModifier
    {
        public Owner(string value)
        {
            this.Value = value;
        }

        public static Owner Any
        {
            get
            {
                return new Owner(string.Empty);
            }
        }

        public static Owner Is(string value)
        {
            return new Owner(value);
        }

        public string Value { get; set; }

        public void Apply(Dictionary<string, string> parameters, Connection connection)
        {
            if (string.IsNullOrEmpty(this.Value)) return;
            parameters.Add("owner", this.Value);
        }
    }
}
