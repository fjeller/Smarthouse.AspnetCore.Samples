using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptionsSample.OptionsClasses;

namespace OptionsSample.Models
{
	public class IndexModel
	{

		#region Properties

		/// =================================================================================================================
		/// <summary>
		/// The caching times, as a prepared list of strings
		/// </summary>
		/// =================================================================================================================
		public List<string> CachingTimes { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The name of the application
		/// </summary>
		/// =================================================================================================================
		public string ApplicationName { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The translations, as they come from the configuration
		/// </summary>
		/// =================================================================================================================
		public TranslationOptions Translations { get; set; }

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		/// The Constructor
		/// </summary>
		/// =================================================================================================================
		public IndexModel()
		{
			CachingTimes = new List<string>();
		}

		#endregion

	}
}
