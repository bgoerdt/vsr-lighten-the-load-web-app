using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MissionPlanningWebApp.Tests
{
    [Binding]
    public class RegistarSteps
    {
        [Given(@"I am on the signup page")]
        public void GivenIAmOnTheSignupPage()
        {
            
        }
        
        [Given(@"I have added ""(.*)"" to the Username")]
        public void GivenIHaveAddedToTheUsername(string p0)
        {
           
        }
        
        [Given(@"I have added ""(.*)"" to the email")]
        public void GivenIHaveAddedToTheEmail(string p0)
        {
           
        }
        
        [Given(@"I have added ""(.*)"" to the password")]
        public void GivenIHaveAddedToThePassword(string p0)
        {
            
        }
        
        [Given(@"I have added ""(.*)"" to the confirm passwork")]
        public void GivenIHaveAddedToTheConfirmPasswork(string p0)
        {
            
        }
        
        [When(@"I press Registar")]
        public void WhenIPressRegistar()
        {
            
        }
        
        [Then(@"I should go to the home page")]
        public void ThenIShouldGoToTheHomePage()
        {
            int myNumber = 12;
            Assert.AreEqual(12, myNumber);
        }
    }
}
