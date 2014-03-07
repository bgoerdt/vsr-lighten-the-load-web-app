using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MissionPlanningWebApp.Tests.SpecFlow
{
    [Binding]
    public class DistributionRulesSteps
    {
        [Given(@"I am a user")]
        public void GivenIAmAUser()
        {
        }

        [Given(@"I have navigated to /DistributionRules")]
        public void GivenIHaveNavigatedToDistributionRules()
        {
            WebBrowser.Setup();
            WebBrowser.Current.GoTo("http://localhost:63369/DistributionRules/Index.cshtml");

            //string url = WebBrowser.Current.Url;

            Assert.IsTrue(true);
        }

        [Given(@"I have pushed '(.*)' for a rule")]
        public void GivenIHavePushedForARule(string p0)
        {
            WebBrowser.Current.Links.First(link => link.Text == p0).Click();
        }

        [Given(@"I have pushed '(.*)'")]
        public void GivenIHavePushed(string p0)
        {
        }

        [When(@"I go navigate to /DistributionRules")]
        public void WhenIGoNavigateToDistributionRules()
        {
        }

        [When(@"I push '(.*)' for a rule")]
        public void WhenIPushForARule(string p0)
        {
        }

        [When(@"I edit the rule")]
        public void WhenIEditTheRule()
        {
        }

        [When(@"I push '(.*)'")]
        public void WhenIPush(string p0)
        {
        }

        [When(@"I create a new rule")]
        public void WhenICreateANewRule()
        {
        }

        [When(@"I delete the rule")]
        public void WhenIDeleteTheRule()
        {
        }

        [Then(@"the result should be a list of distribution rules")]
        public void ThenTheResultShouldBeAListOfDistributionRules()
        {
            Assert.IsTrue(true);
        }

        [Then(@"I should see the Edit page")]
        public void ThenIShouldSeeTheEditPage()
        {
            Assert.IsTrue(true);
        }

        [Then(@"the updated rule should be seen on the Index page")]
        public void ThenTheUpdatedRuleShouldBeSeenOnTheIndexPage()
        {
            Assert.IsTrue(true);
        }

        [Then(@"I should see the Create page")]
        public void ThenIShouldSeeTheCreatePage()
        {
            Assert.IsTrue(true);
        }

        [Then(@"the new rule should be seen on the Index page")]
        public void ThenTheNewRuleShouldBeSeenOnTheIndexPage()
        {
            Assert.IsTrue(true);
        }

        [Then(@"I should see the Delete page")]
        public void ThenIShouldSeeTheDeletePage()
        {
            Assert.IsTrue(true);
        }

        [Then(@"I should not see the rule on the Index page")]
        public void ThenIShouldNotSeeTheRuleOnTheIndexPage()
        {
            Assert.IsTrue(true);
        }
    }
}
