using System;
using System.Collections.Generic;
using System.Text;

namespace com.gogrid.api
{
    public class LoadBalancer
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

        private Ip _IP;
        public Ip IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        private ServerType _load_Balancer_Type;
        public ServerType Load_Balancer_Type
        {
            get { return _load_Balancer_Type; }
            set { _load_Balancer_Type = value; }
        }

        private Persistence _persistences;
        public Persistence Persistences
        {
            get { return _persistences; }
            set { _persistences = value; }
        }

        private Ip _realIpList;
        public Ip RealIpList
        {
            get { return _realIpList; }
            set { _realIpList = value; }
        }

        private ServerOs _os;
        public ServerOs OS
        {
            get { return _os; }
            set { _os = value; }
        }

        private ServerState _state;
        public ServerState State
        {
            get { return _state; }
            set { _state = value; }
        }

        private Messages _message;
        public Messages Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
