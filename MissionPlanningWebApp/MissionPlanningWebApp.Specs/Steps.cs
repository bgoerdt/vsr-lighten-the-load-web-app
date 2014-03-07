using System;
using System.Configuration;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MissionPlanningWebApp.Controllers;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Specs
{
    [Binding]
    public class Steps
    {
		HomeController homeController = new HomeController();
		MissionRuleController mRuleController = new MissionRuleController();

        [Given(@"you are on the home page")]
        public void GivenYouAreOnTheHomePage()
        {
			ActionResult result = homeController.Index();
        }
        
        [Given(@"these mission rules exist")]
        public void GivenTheseMissionRulesExist(Table table)
        {
			foreach (var row in table.Rows)
			{
				MissionRule rule = new MissionRule(Convert.ToInt32(row["ID"]),Convert.ToInt32(row["ParamIndex"]),row["RuleCond"],Convert.ToInt32(row["RuleData"]),Convert.ToInt32(row["EquipIndex"]),row["ConstrCond"],Convert.ToInt32(row["ConstrRHS"]));
				mRuleController.Create(rule);
			}
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
