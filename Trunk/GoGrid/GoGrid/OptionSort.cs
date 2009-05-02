using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class OptionSort : IModifier
    {
        public OptionSort(string attribute, bool ascending)
        {
            this.Attribute = attribute;
            this.Ascending = ascending;
        }

        public string Attribute { get; set; }
        public bool Ascending { get; set; }

        public static OptionSort IDAscending
        {
            get { return new OptionSort("id", true); }
        }

        public static OptionSort NameAscending
        {
            get { return new OptionSort("name", true); }
        }

        public static OptionSort DescriptionAscending
        {
            get { return new OptionSort("description", true); }
        }

        public static OptionSort IDDescending
        {
            get { return new OptionSort("id", false); }
        }

        public static OptionSort NameDescending
        {
            get { return new OptionSort("name", false); }
        }

        public static OptionSort DescriptionDescending
        {
            get { return new OptionSort("description", false); }
        }

        public static OptionSort None
        {
            get { return new OptionSort(string.Empty, false); }
        }

        public void Apply(Dictionary<string, string> parameters, Connection connection)
        {
            if (string.IsNullOrEmpty(this.Attribute)) return;
            parameters.Add("sort", this.Attribute);
            parameters.Add("asc", this.Ascending.ToString().ToLower());
        }
    }
}
