using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationSample.ConfigurationClasses;

namespace ConfigurationSample.Models
{
	public class IndexModel
	{

		public CacheConfiguration CacheConfiguration { get; set; }

		public string DefaultIsinPrefix { get; set; }

		public int DefaultPageSize { get; set; }

		public int DefaultNewsCount { get; set; }

	}
}
