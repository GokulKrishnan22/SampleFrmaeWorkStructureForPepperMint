using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SampleFrameWorkForPepeprMint.pages;
using SampleFrameWorkForPepeprMint.Selenium;

namespace SampleFrameWorkForPepeprMint.Test.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforAll()
        {
            FW.SetConfig();
            FW.CreateTestResultDirectory();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Page.Init();
            Driver.Goto(FW.Config.Test.Url);
        }

        //[OneTimeTearDown] Execute after all Test execution completed.
        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if(outcome == TestStatus.Passed)
			{
                FW.Log.Info("Outcome: Passed");
			}
            else if(outcome == TestStatus.Failed)
			{
                Driver.TakeScreenShot("test_failed");
                FW.Log.Info("Outcome: Failed");
			}
			else
			{
                FW.Log.Info("Outcome: "+outcome);
			}
            Driver.Quit();
        }
    }
}
