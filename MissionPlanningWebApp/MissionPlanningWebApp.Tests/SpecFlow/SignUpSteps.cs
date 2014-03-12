using System;
using TechTalk.SpecFlow;

namespace MissionPlanningWebApp.Tests.SpecFlow
{
    [Binding]
    public class SignUpSteps
    {
        [Given(@"I am on the signup page")]
        public void GivenIAmOnTheSignupPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have added ""(.*)"" to the Username")]
        public void GivenIHaveAddedToTheUsername(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have added ""(.*)"" to the email")]
        public void GivenIHaveAddedToTheEmail(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have added ""(.*)"" to the password")]
        public void GivenIHaveAddedToThePassword(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have added ""(.*)"" to the confirm passwork")]
        public void GivenIHaveAddedToTheConfirmPasswork(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Registar")]
        public void WhenIPressRegistar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should go to the home page")]
        public void ThenIShouldGoToTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
