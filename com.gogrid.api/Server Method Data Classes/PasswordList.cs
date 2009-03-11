using System;
using System.Collections.Generic;

using System.Text;

namespace com.gogrid.api
{
    public class PasswordList
    {
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _applicationType;
        public string ApplicationType
        {
            get { return _applicationType; }
            set { _applicationType= value; }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName= value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password= value; }
        }

        private ServerList _serverList;
        public ServerList ServerList
        {
            get { return _serverList; }
            set { _serverList= value; }
        }

    }
}
