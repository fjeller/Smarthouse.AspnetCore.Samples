using System.Collections.Generic;

namespace OptionsSample.OptionsClasses
{
	public class CachingOptions 
	{

		public List<CachingOptionsItem> Items { get; set; }

		public CachingOptions()
		{
			Items = new List<CachingOptionsItem>();
		}

	}
}
