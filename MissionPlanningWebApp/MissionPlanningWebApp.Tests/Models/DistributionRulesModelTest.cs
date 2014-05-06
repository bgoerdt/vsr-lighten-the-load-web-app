using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Tests.Models
{
    [TestClass]
    public class DistributionRulesModelTest
    {
        [TestMethod]
        public void DistributionRulesModel()
        {
            DistributionRules model = new DistributionRules();

            model.ChrId = 0;
            model.ChrCond = "<";
            model.ChrData = "0";
            model.EquipId = 0;
            model.ConstrCond = "<";
            model.ConstrRHS = 0;

            Assert.AreEqual(model.ChrId, 0);
            Assert.AreEqual(model.ChrCond, "<");
            Assert.AreEqual(model.ChrData, "0");
            Assert.AreEqual(model.EquipId, 0);
            Assert.AreEqual(model.ConstrCond, "<");
            Assert.AreEqual(model.ConstrRHS, 0);
        }
    }
}
