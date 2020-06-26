using OpenQA.Selenium;
using SampleFrameWorkForPepeprMint.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkForPepeprMint.pages
{
	public class HomePage : PageBase
	{
		public readonly HomePageMap map;

		public HomePage() : base()
		{
			map = new HomePageMap();
		}

		public string ProfileName()
		{
			//Driver.Wait.Until(drvr => Page.profilePage.map.profile_name.Displayed);


			//Driver.Wait.Until(WaitConditions.ElementDisplayed(profilePage.map.profile_name));
			//return profilePage.map.profile_name.Text;

			return Driver.Wait.Until(WaitConditions.ElementIsDisplayed(profilePage.map.profile_name)).
				Text;
		}

		public ProfilePage GoToProfile()
		{
			profilePage.map.profile_name.Click();
			return profilePage;
		}
	}

	public class HomePageMap
	{

	}
}
