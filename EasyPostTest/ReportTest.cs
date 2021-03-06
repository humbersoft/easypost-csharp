﻿using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using EasyPost;

namespace EasyPostTest {
    [TestClass]
    public class ReportTest {
        [TestInitialize]
        public void Initialize() {
            ClientManager.SetCurrent("cueqNZUb3ldeWTNX7MU3Mel8UXtaAMUi");
        }

        [TestMethod]
        public void TestCreateAndRetrieve() {
            Dictionary<string, object> parameters = new Dictionary<string, object>() {
                { "include_children", true },
                // Unfortunately, this can only be run once a day. If you need to test more than that change the date here.
                //{ "end_date", "2016-06-01" }
            };
            Report report = Report.Create("shipment", parameters);
            Assert.IsNotNull(report.id);
            Assert.IsTrue(report.include_children);

            Report retrieved = Report.Retrieve("shipment", report.id);
            Assert.AreEqual(report.id, retrieved.id);
        }

        [TestMethod]
        public void TestList() {
            ReportList reportList = Report.List("shipment");
            Assert.AreNotEqual(0, reportList.reports.Count);

            ReportList nextReportList = reportList.Next();
            Assert.AreNotEqual(reportList.reports[0].id, nextReportList.reports[0].id);
        }
    }
}
