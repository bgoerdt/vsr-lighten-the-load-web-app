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

            model.ChrIndex = 0;
            model.ChrCond = "<";
            model.ChrData = 0;
            model.EquipIndex = 0;
            model.ConstrCond = "<";
            model.ConstrRHS = 0;

            Assert.AreEqual(model.ChrIndex, 0);
            Assert.AreEqual(model.ChrCond, "<");
            Assert.AreEqual(model.ChrData, 0);
            Assert.AreEqual(model.EquipIndex, 0);
            Assert.AreEqual(model.ConstrCond, "<");
            Assert.AreEqual(model.ConstrRHS, 0);
        }
    }
}
