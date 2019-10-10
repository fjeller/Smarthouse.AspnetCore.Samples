using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsSample.OptionsClasses
{
	public class CacheOptions
	{

		public List<CacheOptionItem> Items { get; set; }

		public CacheOptions()
		{
			Items = new List<CacheOptionItem>();
		}

	}
}
