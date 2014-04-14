using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MissionPlanningWebApp.Models;
namespace MissionPlanningWebApp.Tests.Models
{
    [TestClass]
    public class MissionRuleTest
    {
        [TestMethod]
        public void MissionRule()
        {
            // arrange
            MissionRule missionRule = new MissionRule();
            missionRule.ID = 10;
            missionRule.ParamId = 5;
            missionRule.RuleCond = "night";
            missionRule.RuleData = 6;
            missionRule.EquipId = 8;
                 missionRule.ConstrCond = "daylight";
            missionRule.ConstrRHS = 14;


       
            // act


            // assert

       
            Assert.AreEqual(missionRule.ID, 10);
            Assert.AreEqual(missionRule.ParamId, 5);
            Assert.AreEqual(missionRule.RuleCond, "night");
            Assert.AreEqual(missionRule.RuleData, 6);
            Assert.AreEqual(missionRule.EquipId, 8);
            Assert.AreEqual(missionRule.ConstrCond, "daylight");
            Assert.AreEqual(missionRule.ConstrRHS, 14);

        }
    }
}
