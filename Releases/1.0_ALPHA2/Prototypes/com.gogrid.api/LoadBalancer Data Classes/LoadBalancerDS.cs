using System;
using System.Collections.Generic;
using System.Text;

namespace com.gogrid.api
{
    public class LoadBalancerDS
    {
        private string _id;
        private string _name;
        private string _description;
        private string _VIP_ID;
        private string _VIP_IP;
        private string _VIP_Subnet;
        private string _VIP_Public;
        private string _VIP_Port;

        private string _Type_ID;
        private string _Type_Name;
        private string _Type_Desctiption;

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
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        //Virtual IP Information

        public string VIP_ID
        {
            get { return _VIP_ID; }
            set { _VIP_ID= value; }
        }
        public string VIP_IP
        {
            get { return _VIP_IP; }
            set { _VIP_IP = value; }
        }
        public string VIP_Subnet
        {
            get { return _VIP_Subnet; }
            set { _VIP_Subnet= value; }
        }
        public string VIP_Public
        {
            get { return _VIP_Public; }
            set { _VIP_Public = value; }
        }
        public string VIP_Port
        {
            get { return _VIP_Port; }
            set { _VIP_Port= value; }
        }

        //Type Information

        public string Type_ID
        {
            get { return _Type_ID; }
            set { _Type_ID= value; }
        }
        public string Type_Name
        {
            get { return _Type_Name; }
            set { _Type_Name= value; }
        }
        public string Type_Description
        {
            get { return _Type_Desctiption; }
            set { _Type_Desctiption = value; }
        }

        //Persistence
        private string _Persistence_ID;
        private string _Persistence_Name;
        private string _Persistence_Description;

        public string Persistence_ID
        {
            get { return _description; }
            set { _Persistence_ID = value; }
        }
        public string Persistence_Name
        {
            get { return _Persistence_Name; }
            set { _Persistence_Name = value; }
        }
        public string Persistence_Description
        {
            get { return _Persistence_Description; }
            set { _Persistence_Description = value; }
        }

        //Real IP List
        private string _RealIP_ID;
        private string _RealIP_IP;
        private string _RealIP_Subnet;
        private string _RealIP_Public;
        private string _RealIP_Port;

        public string RealIP_ID
        {
            get { return _RealIP_ID; }
            set { _RealIP_ID = value; }
        }
        public string RealIP_IP
        {
            get { return _RealIP_IP; }
            set { _RealIP_IP = value; }
        }
        public string RealIP_Subnet
        {
            get { return _RealIP_Subnet; }
            set { _RealIP_Subnet = value; }
        }
        public string RealIP_Public
        {
            get { return _RealIP_Public; }
            set { _RealIP_Public = value; }
        }
        public string RealIP_Port
        {
            get { return _RealIP_Port; }
            set { _RealIP_Port = value; }
        }

        //Os Inforamtion
        private string _OS_ID;
        private string _OS_Name;
        private string _OS_Description;

        public string OS_ID
        {
            get { return _OS_ID; }
            set { _OS_ID = value; }
        }
        public string OS_Name
        {
            get { return _OS_Name; }
            set { _OS_Name = value; }
        }
        public string OS_Description
        {
            get { return _OS_Description; }
            set { _OS_Description = value; }
        }

        //State Info
        private string _State_ID;
        private string _Sstate_Name;
        private string _State_Description;

        public string State_ID
        {
            get { return _State_ID; }
            set { _State_ID = value; }
        }
        public string State_Name
        {
            get { return _Sstate_Name; }
            set { _Sstate_Name = value; }
        }
        public string State_Description
        {
            get { return _State_Description; }
            set { _State_Description = value; }
        }

        //Message
        private bool _success;
        private string _message;

        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }



    }
}
