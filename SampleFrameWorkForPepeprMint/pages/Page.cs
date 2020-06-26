using System;

namespace SampleFrameWorkForPepeprMint.pages
{
	public class Page
	{
		[ThreadStatic]
		public static LoginPage loginPage;

		[ThreadStatic]
		public static HomePage homePage;

		[ThreadStatic]
		public static ProfilePage profilePage;

		public static void Init()
		{
			loginPage = new LoginPage();
			homePage = new HomePage();
			profilePage = new ProfilePage();
		}
	}
}
