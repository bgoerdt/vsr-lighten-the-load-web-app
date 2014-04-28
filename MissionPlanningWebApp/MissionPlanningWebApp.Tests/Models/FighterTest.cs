using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MissionPlanningWebApp.Models;
namespace MissionPlanningWebApp.Tests.Models
{
    [TestClass]
    public class FighterTest
    {
        [TestMethod]
        public void Fighter()
        {
            // arrange
            Fighter fighter = new Fighter();
            fighter.Name = "marine";
            fighter.ID = 2;
            FighterCharacteristic fighterChar = new FighterCharacteristic(2,4,8);
            FighterCharacteristic fighterChar2 = new FighterCharacteristic(); 
            

            //
          
            // act


            // assert

            Assert.AreEqual(fighter.Name, "marine");
            Assert.AreEqual(fighter.ID, 2);

           

         

        }
    }
}
