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
            //
          
            // act


            // assert

            Assert.AreEqual(fighter.Name, "marine");
            Assert.AreEqual(fighter.ID, 2);

           

         

        }
    }
}
