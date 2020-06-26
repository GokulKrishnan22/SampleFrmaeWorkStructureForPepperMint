using OpenQA.Selenium;

namespace SampleFrameWorkForPepeprMint.pages
{
	//Inherit By other 'objects' not inizated by itself
	public abstract class PageBase
	{
		
		public readonly ProfilePage profilePage;

		public PageBase()
		{
			profilePage = new ProfilePage();
		}
	}
}
