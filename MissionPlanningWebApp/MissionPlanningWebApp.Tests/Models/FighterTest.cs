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
            Warfighter fighter = new Warfighter();
            fighter.Name = "marine";
            fighter.ID = 2;
            WarfighterCharacteristic fighterChar = new WarfighterCharacteristic(2,4,"8");
            WarfighterCharacteristic fighterChar2 = new WarfighterCharacteristic(); 
            

            //
          
            // act


            // assert

            Assert.AreEqual(fighter.Name, "marine");
            Assert.AreEqual(fighter.ID, 2);

           

         

        }
    }
}
