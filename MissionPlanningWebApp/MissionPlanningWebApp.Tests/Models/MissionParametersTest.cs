using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Tests.Models

{
    [TestClass]
    public class MissionParametersTest
    {
        [TestMethod]
        public void MissionParameters()
        {
            // arrange
            MissionParameter missionParameter = new MissionParameter();
            missionParameter.Name = "knife";
           // missionParameter.Value = 2;
          //
            // act


            // assert

            Assert.AreEqual(missionParameter.Name, "knife");
           // Assert.AreEqual(missionParameter.value, 2);
           
            
        }
    }
}
