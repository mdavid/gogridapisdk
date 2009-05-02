using System;
using System.Collections.Generic;

using System.Text;

namespace com.gogrid.api
{
    public class Ip
    {
        private string _id;
        private string _ip;
        private string _subnet;
        private string _public;
        private string _port;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public string Subnet
        {
            get { return _subnet; }
            set { _subnet = value; }
        }
        public string Public
        {
            get { return _public; }
            set { _public = value; }
        }
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private Messages _message;
        public Messages Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
