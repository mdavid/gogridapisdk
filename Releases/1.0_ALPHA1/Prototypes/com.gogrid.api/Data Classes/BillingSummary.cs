using System;
using System.Collections.Generic;
using System.Text;

namespace com.gogrid.api
{
    public class BillingSummary
    {
        
        private string _startDate;

        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }


        private string _endDate;

        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }


        private string _memoryAllotment;

        public string MemoryAllotment
        {
            get { return _memoryAllotment; }
            set { _memoryAllotment = value; }
        }


        private string _memoryInuse;

        public string MemoryInUse
        {
            get { return _memoryInuse; }
            set { _memoryInuse = value; }
        }


        private string _memoryAccured;

        public string MemoryAccured
        {
            get { return _memoryAccured; }
            set { _memoryAccured = value; }
        }


        private string _memoryOverage;

        public string MemoryOverage
        {
            get { return _memoryOverage; }
            set { _memoryOverage = value; }
        }


        private string _memoryOverageCharge;

        public string MemoryOverageCharge
        {
            get { return _memoryOverageCharge; }
            set { _memoryOverageCharge = value; }
        }


        private string _transferAllotment;

        public string TransferAllotment
        {
            get { return _transferAllotment; }
            set { _transferAllotment = value; }
        }

        private string _transferAccorrued;

        public string TransferAccorrued
        {
            get { return _transferAccorrued; }
            set { _transferAccorrued = value; }
        }

        
        private string _transferOverage;
        public string TransferOverage 
        {
            get { return _transferOverage; }
            set { _transferOverage = value; }
        }

        private string _transferOverageCharge;

        public string TransferOverageCharge
        {
            get { return _transferOverageCharge; }
            set { _transferOverageCharge = value; }
        }

    }
}
