using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using OptionsSample.OptionClasses;

namespace OptionsSample.Pages
{
	public class IndexModel : PageModel
	{
		#region Private Fields

		private DefaultCachingOptions _defaultCachingOptions;
		private TestConfig _myTestConfig;
		private NamesAndValuesOptions _nameValueOptions;

		#endregion

		#region Public Properties (usable in the View/Page)

		public int DefaultCachingTime { get; set; }

		public int ShareCachingTime { get; set; }

		public string Name { get; set; }

		public Dictionary<string,string> NamesAndValues { get; set; }

		#endregion

		public void OnGet()
		{
			DefaultCachingTime = this._defaultCachingOptions.DefaultCachingTime;
			ShareCachingTime = this._defaultCachingOptions.ShareCachingTime;
			Name = _myTestConfig.Name;
			NamesAndValues = this._nameValueOptions.ToDictionary(k => k.Key, k => k.Value);
		}

		public IndexModel( IOptionsMonitor<DefaultCachingOptions> cachingOptionsAccessor, IOptionsMonitor<TestConfig> testConfigAccessor, IOptionsMonitor<NamesAndValuesOptions> nameValuesOptionsAccessor )
		{
			this._defaultCachingOptions = cachingOptionsAccessor.CurrentValue;
			this._myTestConfig = testConfigAccessor.CurrentValue;
			this._nameValueOptions = nameValuesOptionsAccessor.CurrentValue;
		}
	}
}
