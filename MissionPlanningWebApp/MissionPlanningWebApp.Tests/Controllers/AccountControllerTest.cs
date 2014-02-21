﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionPlanningWebApp.Models;
using MissionPlanningWebApp.Controllers;
using System.Web.Security;
using System.Web.Mvc;

namespace MissionPlanningWebApp.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Login()
        {
            AccountController accountController = new AccountController();
            ViewResult viewResult = accountController.Login() as ViewResult;

            Assert.AreEqual(viewResult.ViewName, "Login");
        }

        [TestMethod]
        public void Register()
        {
            AccountController accountController = new AccountController();
            ViewResult viewResult = accountController.Register() as ViewResult;

            Assert.AreEqual(viewResult.ViewName, "Register");
        }

      
    }
}
