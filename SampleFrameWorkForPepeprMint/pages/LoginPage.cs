using OpenQA.Selenium;
using SampleFrameWorkForPepeprMint.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleFrameWorkForPepeprMint.pages
{
	public class LoginPage
	{
		public readonly LoginPageMap map;

		public LoginPage()
		{
			map = new LoginPageMap();
		}

		public void Login(string user_name, string password)
		{
			map.user_name.SendKeys(user_name);
			map.password.SendKeys(password);
			map.login_btn.Click();
		}
	}

	public class LoginPageMap
	{
		public Element user_name => Driver.FindElement(By.XPath("//input[@id='email']"), "User Name");
        public Element password => Driver.FindElement(By.XPath("//input[@id='pass']"), "Password");
		public Element login_btn => Driver.FindElement(By.XPath("//input[@type='submit']"), "Login Button");	
	}
}
