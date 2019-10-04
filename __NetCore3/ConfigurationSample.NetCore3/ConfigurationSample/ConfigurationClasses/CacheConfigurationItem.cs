using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationSample.ConfigurationClasses
{

	//[DebuggerDisplay("{Name}: {Hours}:{Minutes}:{Seconds}")]
	public class CacheConfigurationItem
	{

		/// =================================================================================================================
		/// <summary>
		/// The name of the cache configuration item
		/// </summary>
		/// =================================================================================================================
		public string Name { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The number of hours the item should be cached
		/// </summary>
		/// =================================================================================================================
		public int Hours { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The number of minutes the item should be cached
		/// </summary>
		/// =================================================================================================================
		public int Minutes { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The number of seconds the item should be cached
		/// </summary>
		/// =================================================================================================================
		public int Seconds { get; set; }

	}
}
