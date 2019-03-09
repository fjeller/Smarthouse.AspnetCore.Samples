using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationSample.Models
{
	public class TestViewModel
	{

		public string TestValue1 { get; set; }

		public string TestValue2 { get; set; }

		public string[] Names { get; set; }

		public override string ToString()
		{
			return $"{TestValue1} {TestValue2}";
		}

	}
}
