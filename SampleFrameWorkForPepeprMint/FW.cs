using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SampleFrameWorkForPepeprMint.Logging;
using System;
using System.IO;

namespace SampleFrameWorkForPepeprMint
{
	class FW
	{
		//public static string WORK_SPACE_DIRECTORY = Path.GetFullPath(@"../../../../");
		public static string WORK_SPACE_DIRECTORY = Directory.GetCurrentDirectory();

		public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. Call SetLogger() first");

		public static FWConfig Config => _configuration ?? throw new NullReferenceException("Config is null. Call FW.SetConfig() first");

		[ThreadStatic]
		public static DirectoryInfo CurrentTestDirectory;

		[ThreadStatic]
		private static Logger _logger;

		private static FWConfig _configuration;


		public static DirectoryInfo CreateTestResultDirectory()
		{
			var testDirectory = WORK_SPACE_DIRECTORY + "TestResults";

			if (Directory.Exists(testDirectory))
			{
				Directory.Delete(testDirectory, recursive: true);
			}

			return Directory.CreateDirectory(testDirectory);
		}

		public static void SetConfig()
		{
			if (_configuration == null)
			{
				var jsonStr = File.ReadAllText(WORK_SPACE_DIRECTORY + "//framework-config.json");
				_configuration = JsonConvert.DeserializeObject<FWConfig>(jsonStr);
			}
		}

		public static void SetLogger()
		{
			lock (_setLoggerLock) {
				var testResultDir = WORK_SPACE_DIRECTORY + "//TestResults";
				var testName = TestContext.CurrentContext.Test.Name;
				var fullPath = $"{testResultDir}/{testName}";

				if (Directory.Exists(fullPath))
				{
					CurrentTestDirectory = Directory.CreateDirectory(fullPath + TestContext.CurrentContext.Test.ID);
				}
				else
				{
					CurrentTestDirectory = Directory.CreateDirectory(fullPath);
				}

				CurrentTestDirectory = Directory.CreateDirectory(fullPath);
				_logger = new Logger(testName, CurrentTestDirectory.FullName + "//log.txt");
			}
		}

		private static object _setLoggerLock = new object();
	}
}
