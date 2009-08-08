using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoGrid;

namespace TestAssembly0
{
    [TestClass]
    public class PublicHelperTest
    {
        [TestMethod]
        public void TestFromGoGridDateTime()
        {
            string yyyymmddhhmmssstzd = "2008-03-12 14:34:23.234 +05:00";
            string yyyymmdd = "2008-03-12";
            string mmddyyyy = "11/30/2008";
            string mmddyy = "11/30/08";

            DateTimeOffset yyyymmddhhmmssstzdOutput = yyyymmddhhmmssstzd.FromGoGridDateTime();
            Assert.AreEqual(2008, yyyymmddhhmmssstzdOutput.Year);
            Assert.AreEqual(03, yyyymmddhhmmssstzdOutput.Month);
            Assert.AreEqual(12, yyyymmddhhmmssstzdOutput.Day);
            Assert.AreEqual(14, yyyymmddhhmmssstzdOutput.Hour);
            Assert.AreEqual(34, yyyymmddhhmmssstzdOutput.Minute);
            Assert.AreEqual(23, yyyymmddhhmmssstzdOutput.Second);
            Assert.AreEqual(234, yyyymmddhhmmssstzdOutput.Millisecond);
            Assert.AreEqual(TimeSpan.FromHours(5), yyyymmddhhmmssstzdOutput.Offset);

            DateTimeOffset yyyymmddOutput = yyyymmdd.FromGoGridDateTime();
            Assert.AreEqual(2008, yyyymmddOutput.Year);
            Assert.AreEqual(03, yyyymmddOutput.Month);
            Assert.AreEqual(12, yyyymmddOutput.Day);
            Assert.AreEqual(0, yyyymmddOutput.Hour);
            Assert.AreEqual(0, yyyymmddOutput.Minute);
            Assert.AreEqual(0, yyyymmddOutput.Second);
            Assert.AreEqual(0, yyyymmddOutput.Millisecond);
            Assert.AreEqual(TimeSpan.Zero, yyyymmddOutput.Offset);

            DateTimeOffset mmddyyyyOutput = mmddyyyy.FromGoGridDateTime();
            Assert.AreEqual(2008, mmddyyyyOutput.Year);
            Assert.AreEqual(11, mmddyyyyOutput.Month);
            Assert.AreEqual(30, mmddyyyyOutput.Day);
            Assert.AreEqual(0, mmddyyyyOutput.Hour);
            Assert.AreEqual(0, mmddyyyyOutput.Minute);
            Assert.AreEqual(0, mmddyyyyOutput.Second);
            Assert.AreEqual(0, mmddyyyyOutput.Millisecond);
            Assert.AreEqual(TimeSpan.Zero, mmddyyyyOutput.Offset);

            DateTimeOffset mmddyyOutput = mmddyy.FromGoGridDateTime();
            Assert.AreEqual(2008, mmddyyOutput.Year);
            Assert.AreEqual(11, mmddyyOutput.Month);
            Assert.AreEqual(30, mmddyyOutput.Day);
            Assert.AreEqual(0, mmddyyOutput.Hour);
            Assert.AreEqual(0, mmddyyOutput.Minute);
            Assert.AreEqual(0, mmddyyOutput.Second);
            Assert.AreEqual(0, mmddyyOutput.Millisecond);
            Assert.AreEqual(TimeSpan.Zero, mmddyyOutput.Offset);
        }
    }
}
