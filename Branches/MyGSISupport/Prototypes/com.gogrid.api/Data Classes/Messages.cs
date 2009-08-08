using System;
using System.Collections.Generic;

using System.Text;

namespace com.gogrid.api
{
    public class Messages
    {
        private string _error_400;

        public string Error_400
        {
            get { return _error_400; }
            set { _error_400 = value; }
        }

        private string _error_401;
        public string Error_401
        {
            get { return _error_401; }
            set { _error_401 = value; }
        }
        private string _error_403;
        public string Error_403
        {
            get { return _error_403; }
            set { _error_403 = value; }
        }

        private string _error_404;

        public string Error_404
        {
            get { return _error_404; }
            set { _error_404 = value; }
        }

        private string _error_500;

        public string Error_500
        {
            get { return _error_500; }
            set { _error_500 = value; }
        }

        private bool _success;

        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }
    }
}
