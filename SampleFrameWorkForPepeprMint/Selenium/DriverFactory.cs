using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkForPepeprMint.Selenium
{
	public static class DriverFactory
	{
		public static IWebDriver Build(string browserName)
		{
			FW.Log.Info($"Browser: {browserName}");

			switch (browserName)
			{
				case "Chrome":
					return new ChromeDriver();
				case "FireFox":
					return new FirefoxDriver();
				default:
					throw new ArgumentException($"{browserName} not supported");
			}
		}
	}
}
