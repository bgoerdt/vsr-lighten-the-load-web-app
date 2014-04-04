using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MissionPlanningWebApp.Models;
namespace MissionPlanningWebApp.Tests.Models
{
    [TestClass]
    public class EquipmentTest
    {
        [TestMethod]
        public void Equipment()
        {
        
         // arrange
            Equipment equipment = new Equipment();
            equipment.Name = "shovel";
            equipment.ID = 2;
            equipment.Weight = 8;
            equipment.Firepower = 10;
            //
          
            // act


            // assert

            Assert.AreEqual(equipment.Name, "shovel");
            Assert.AreEqual(equipment.ID, 2);
            Assert.AreEqual(equipment.Weight, 8);
            Assert.AreEqual(equipment.Firepower, 10);

        }
    }
}
