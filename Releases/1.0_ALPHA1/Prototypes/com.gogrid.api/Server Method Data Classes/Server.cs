using System;
using System.Collections.Generic;

using System.Text;

namespace com.gogrid.api
{
    public class ServerList
    {
        private string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private Ip _ip;

        public Ip ServerIP 
        { 
            get
            {
                return _ip == null? _ip =  new Ip(): _ip;
            }
            set
            {
                _ip = (Ip)value;
            }
        }

        private Ram _serverRam;

        public Ram ServerRam
        {
            get { return _serverRam; }
            set { _serverRam = value; }
        }

        private ServerImage _serverImage;

        public ServerImage ServerImg
        {
            get { return _serverImage; }
            set { _serverImage = value; }
        }
        private ServerState _serverState;

        public ServerState State
        {
            get { return _serverState; }
            set { _serverState = value; }
        }

        private ServerType _serverType;

        public ServerType ServerT
        {
            get { return _serverType; }
            set { _serverType = value; }
        }
        private ServerOs _serverOs;

        public ServerOs Os
        {
            get { return _serverOs; }
            set { _serverOs = value; }
        }

        private Messages _message;

        public Messages Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
