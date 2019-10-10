using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsSample.OptionsClasses
{
	[DebuggerDisplay("{Name} : {Hours}:{Minutes}:{Seconds}")]
	public class CacheOptionItem
	{

		public string Name { get; set; }

		public int Hours { get; set; }

		public int Minutes { get; set; }

		public int Seconds { get; set; }

	}
}
