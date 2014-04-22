using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionPlanningWebApp.Models;
using System.Collections.Generic;

namespace MissionPlanningWebApp.Tests.Models
{
    [TestClass]
    public class MissionPlanTest
    {
        [TestMethod]
        public void missionPlan()
        {
            // arrange
            MissionPlan missionPlan = new MissionPlan();
            Equipment knife = new Equipment();
            knife.Name = "knife";
            knife.ID = 2;
            knife.Weight = 8;
            knife.Firepower = 10;
            
            missionPlan.NumberOfWarfighters = 3;
            missionPlan.TotalWeightOfEquipment = 90.6;
            missionPlan.EquipmentWeightPerWarfighter = 30.2;
           
            missionPlan.EquipmentList.Add(knife, 10);
           
            //

            // act


            // assert
            Assert.AreEqual(missionPlan.NumberOfWarfighters, 3);
            Assert.AreEqual(missionPlan.TotalWeightOfEquipment, 90.6);
            Assert.AreEqual(missionPlan.EquipmentWeightPerWarfighter, 30.2);

            Assert.IsTrue(missionPlan.EquipmentList.ContainsKey(knife));
            Assert.IsTrue(missionPlan.EquipmentList.ContainsValue(10));
            

        }
    }
}
