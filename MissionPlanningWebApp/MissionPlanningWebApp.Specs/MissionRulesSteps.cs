using System;
using TechTalk.SpecFlow;

namespace MissionPlanningWebApp.Tests
{
    [Binding]
    public class MissionRulesSteps
    {
        [Given(@"you are on the home page")]
        public void GivenYouAreOnTheHomePage()
        {
        }
        
        [Given(@"these mission rules exist")]
        public void GivenTheseMissionRulesExist(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"you click ""(.*)""")]
        public void WhenYouClick(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the mission rules should be displayed")]
        public void ThenTheMissionRulesShouldBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
