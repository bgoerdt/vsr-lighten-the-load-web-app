using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Tests.Models
{
    [TestClass]
    public class AccountModels
    {
        [TestMethod]
        public void Signup()
        {
            // arrange
            RegisterModel account = new RegisterModel();
            account.Email = "gunnar@gunnar.com";
            account.Password = "gunnar1";
            account.UserName = "gunnar";
            account.ConfirmPassword = "gunnar1";
        
            // act
           

            // assert
            
            Assert.AreEqual(account.Email,"gunnar@gunnar.com");
            Assert.AreEqual(account.Password, "gunnar1");
            Assert.AreEqual(account.ConfirmPassword, "gunnar1");
            Assert.AreEqual(account.UserName, "gunnar");
        }

        [TestMethod]
        public void ChangePassword()
        {
            // arrange
            ChangePasswordModel account = new ChangePasswordModel();
            account.OldPassword = "gunnar@gunnar.com";
            account.NewPassword = "gunnar1";
            account.ConfirmPassword = "gunnar1";
         

            // act


            // assert

            Assert.AreEqual(account.OldPassword, "gunnar@gunnar.com");
            Assert.AreEqual(account.NewPassword, "gunnar1");
            Assert.AreEqual(account.ConfirmPassword, "gunnar1");
           

        }

      
        [TestMethod]
        public void LogIn()
        {
            // arrange
            LoginModel account = new LoginModel();
            account.Password = "gunnar1";
            account.UserName = "gunnar";
            account.RememberMe = true;

            // act


            // assert

            
            Assert.AreEqual(account.Password, "gunnar1");
            Assert.AreEqual(account.RememberMe, true);
            Assert.AreEqual(account.UserName, "gunnar");
        }
    }
}
