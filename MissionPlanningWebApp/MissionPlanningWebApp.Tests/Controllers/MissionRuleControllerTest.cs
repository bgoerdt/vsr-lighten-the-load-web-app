using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionPlanningWebApp.Controllers;

namespace MissionPlanningWebApp.Tests.Controllers
{
	[TestClass]
	public class MissionRuleControllerTest
	{
		[TestMethod]
		public void Index()
		{
			MissionRuleController missRuleController = new MissionRuleController();
			ViewResult viewResult = missRuleController.Index() as ViewResult;

			Assert.AreEqual(viewResult.ViewName, "MissionRule");
		}

		[TestMethod]
		public void Details()
		{
			MissionRuleController missRuleController = new MissionRuleController();
			ViewResult viewResult = missRuleController.Details(5) as ViewResult;

			Assert.AreEqual(viewResult.ViewName, "MissionRule/Details/5");
		}

		[TestMethod]
		public void Create()
		{
			MissionRuleController missRuleController = new MissionRuleController();
			ViewResult viewResult = missRuleController.Create() as ViewResult;

			Assert.AreEqual(viewResult.ViewName, "MissionRule/Create");
		}

		[TestMethod]
		public void Edit()
		{
			MissionRuleController missRuleController = new MissionRuleController();
			ViewResult viewResult = missRuleController.Edit(5) as ViewResult;

			Assert.AreEqual(viewResult.ViewName, "MissionRule/Edit/5");
		}

		[TestMethod]
		public void Delete()
		{
			MissionRuleController missRuleController = new MissionRuleController();
			ViewResult viewResult = missRuleController.Delete(5) as ViewResult;

			Assert.AreEqual(viewResult.ViewName, "MissionRule/Delete/5");
		}
	}
}
