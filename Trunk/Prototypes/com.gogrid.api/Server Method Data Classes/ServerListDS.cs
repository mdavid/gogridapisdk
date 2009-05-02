using System;
using System.Collections.Generic;

using System.Text;

namespace com.gogrid.api
{
    public class ServerListDS
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

        private string _IP_Ip;
        public string IP_Ip
        {
            get { return _IP_Ip; }
            set { _IP_Ip = value; }
        }

        private string _IP_ID;
        public string IP_ID 
        {             
            get { return _IP_ID; }
            set { _IP_ID = value; }
        }

        private string _IP_Subnet;
        public string IP_Subnet
        {
            get { return _IP_Subnet; }
            set { _IP_Subnet = value; }
        }

        private string _IP_Public;
        public string IP_Public
        {
            get { return _IP_Public; }
            set { _IP_Public = value; }
        }

        private string _RamID;
        public string RamID
        {
            get { return _RamID; }
            set { _RamID = value; }
        }

        private string _RamName;
        public string RamName
        {
            get { return _RamName; }
            set { _RamName = value; }
        }

        private string _RamDescription;
        public string RamDescription
        {
            get { return _RamDescription; }
            set { _RamDescription = value; }
        }

        private string _Image_ID;
        public string Image_ID
        {
            get { return _Image_ID; }
            set { _Image_ID = value; }
        }

        private string _Image_Name;
        public string Image_Name
        {
            get { return _Image_Name; }
            set { _Image_Name = value; }
        }

        private string _Image_FriendlyName;
        public string Image_FriendlyName
        {
            get { return _Image_FriendlyName; }
            set { _Image_FriendlyName = value; }
        }

        private string _Image_Description;
        public string Image_Description
        {
            get { return _Image_Description; }
            set { _Image_Description = value; }
        }

        private string _Image_Location;
        public string Image_Location
        {
            get { return _Image_Location; }
            set { _Image_Location = value; }
        }

        private string _Image_isActive;
        public string Image_isActive
        {
            get { return _Image_isActive; }
            set { _Image_isActive = value; }
        }

        private string _Image_isPublic;
        public string Image_isPublic
        {
            get { return _Image_isPublic; }
            set { _Image_isPublic = value; }
        }

        private string _Image_CreatedTime;
        public string Image_CreatedTime
        {
            get { return _Image_CreatedTime; }
            set { _Image_CreatedTime = value; }
        }

        private string _Image_UpdatedTime;
        public string Image_UpdatedTime
        {
            get { return _Image_UpdatedTime; }
            set { _Image_UpdatedTime = value; }
        }

        private string _State_ID;
        public string State_ID
        {
            get { return _State_ID; }
            set { _State_ID = value; }
        }

        private string _State_Name;
        public string State_Name
        {
            get { return _State_Name; }
            set { _State_Name = value; }
        }

        private string _State_Description;
        public string State_Description
        {
            get { return _State_Description; }
            set { _State_Description = value; }
        }

        private string _OS_ID;
        public string OS_ID
        {
            get { return _OS_ID; }
            set { _OS_ID = value; }
        }

        private string _OS_Name;
        public string OS_Name
        {
            get { return _OS_Name; }
            set { _OS_Name = value; }
        }

        private string _OS_Description;
        public string OS_Description
        {
            get { return _OS_Description; }
            set { _OS_Description = value; }
        }


        private string _error_400;

        public string Message_Error_400
        {
            get { return _error_400; }
            set { _error_400 = value; }
        }

        private string _error_401;
        public string Message_Error_401
        {
            get { return _error_401; }
            set { _error_401 = value; }
        }

        private string _error_403;
        public string Message_Error_403
        {
            get { return _error_403; }
            set { _error_403 = value; }
        }

        private string _error_404;

        public string Message_Error_404
        {
            get { return _error_404; }
            set { _error_404 = value; }
        }

        private string _error_500;

        public string Message_Error_500
        {
            get { return _error_500; }
            set { _error_500 = value; }
        }
        private bool _Message_Success;
        public bool Message_Success
        {
            get { return _Message_Success; }
            set { _Message_Success = value; }
        }
        
    }
}
