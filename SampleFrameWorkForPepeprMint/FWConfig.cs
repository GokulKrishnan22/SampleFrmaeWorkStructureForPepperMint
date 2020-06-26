using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkForPepeprMint
{
	public class FWConfig
	{
		public DriverSettings Driver { get; set; }

		public TestSettings Test { get; set; }

	}

	public class DriverSettings
	{
		public string Browser { get; set; }
	}

	public class TestSettings
	{
		public string Url { get; set; }
	}
}
