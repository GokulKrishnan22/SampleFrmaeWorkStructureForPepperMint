using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SampleFrameWorkForPepeprMint.pages;
using SampleFrameWorkForPepeprMint.Selenium;
using SampleFrameWorkForPepeprMint.Test.Base;
using System;

namespace SampleFrameWorkForPepeprMint
{
    [TestFixture]
    public class TestClass : TestBase
    {
        [Test, Category("Smoke Test")]
        public void TestMethod1()
        {
            
            Page.loginPage.Login("7200704979", "Gokul@22");
           
            Assert.AreEqual("Gokul Krishnan", Page.homePage.ProfileName());

            var profilePage = Page.homePage.GoToProfile();
            profilePage.SwitchTab("About");
            
        }
    }

}
