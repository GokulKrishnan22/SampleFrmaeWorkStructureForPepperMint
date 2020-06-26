

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace SampleFrameWorkForPepeprMint.Selenium
{
	public static class Driver
	{
		[ThreadStatic]
		private static IWebDriver _driver;

		public static Wait Wait;

		public static void Init( )
		{
			_driver = DriverFactory.Build(FW.Config.Driver.Browser);
			Wait = new Wait(10);
		}

		public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

		public static void Goto(string url)
		{
			Current.Manage().Window.Maximize();
			Current.Navigate().GoToUrl(url);
			FW.Log.Info(url);
		}

		public static void Quit()
		{
			FW.Log.Info("Close Browser");
			Current.Quit();
			Current.Dispose();
		}

		public static string Title => Current.Title;

		public static Element FindElement(By by, string elementName)
		{
			return new Element(Current.FindElement(by), elementName)
			{
				FoundBy = by
			};
		}

		public static Elements FindElements(By by)
		{
			return new Elements(Current.FindElements(by))
			{
				FoundBy = by
			};
		}

		public static void TakeScreenShot(string imageName)
		{
			var ss = ((ITakesScreenshot)Current).GetScreenshot();
			var ssFileName = Path.Combine(FW.CurrentTestDirectory.FullName, imageName);
			ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);

		}
	}
}