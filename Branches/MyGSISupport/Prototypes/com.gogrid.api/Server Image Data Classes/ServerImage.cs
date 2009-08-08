using System;
using System.Collections.Generic;

using System.Text;

namespace com.gogrid.api
{
    public class ServerImage
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


        private string _friendlyName;

        public string FriendlyName
        {
            get { return _friendlyName; }
            set { _friendlyName = value; }
        }


        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }


        private string _isActive;

        public string isActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }


        private string _isPublic;

        public string isPublic
        {
            get { return _isPublic; }
            set { _isPublic = value; }
        }


        private string _createdTime;

        public string CreatedTime
        {
            get { return _createdTime; }
            set { _createdTime = value; }
        }


        private string _updatedTime;

        public string UpdatedTime
        {
            get { return _updatedTime; }
            set { _updatedTime = value; }
        }


    }
}
