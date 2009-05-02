using System;
using System.Collections.Generic;

using System.Text;

namespace com.gogrid.api
{
    public class Ram
    {
        private string _id;
        private string _name;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get
            {
                return _name;

            }
            set
            {
                _name = value;
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
