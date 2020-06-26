
using NUnit.Framework;
using OpenQA.Selenium;
using SampleFrameWorkForPepeprMint.Selenium;

namespace SampleFrameWorkForPepeprMint.pages
{
	public class ProfilePage
	{
		public readonly ProfilePageMap map;

		public ProfilePage()
		{
			map = new ProfilePageMap();
		}

		public void IsPageDisplayed()
		{

			Assert.That(map.profile_page.Displayed);
		}

		public void SwitchTab(string tabName)
		{
			map.TabButton(tabName).Click();
		}

	}

	public class ProfilePageMap
	{
		public Element profile_page => Driver.FindElement(By.XPath("//div[@id='timeline_top_section']"), "Profile Page");
		public Element TabButton(string tabName) => Driver.FindElement(By.XPath($"//a[text()='{tabName}']"), $"{tabName} button"); 
		public Element profile_name => Driver.FindElement(By.XPath("//a[@data-testid='left_nav_item_Gokul Krishnan']//div"), "Profile Name");
	}
}

