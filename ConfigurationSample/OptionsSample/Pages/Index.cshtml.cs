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
		private DefaultCachingOptions _snapshotOptions;
		private TestConfig _myTestConfig;

		#endregion

		#region Public Properties (usable in the View/Page)

		public int DefaultCachingTime { get; set; }

		public int ShareCachingTime { get; set; }
		public int SnapshotDefaultCachingTime { get; set; }

		public int SnapshotShareCachingTime { get; set; }

		public string Name { get; set; }

		#endregion

		public void OnGet()
		{
			DefaultCachingTime = this._defaultCachingOptions.DefaultCachingTime;
			ShareCachingTime = this._defaultCachingOptions.ShareCachingTime;
			SnapshotDefaultCachingTime = this._snapshotOptions.DefaultCachingTime;
			SnapshotShareCachingTime = this._snapshotOptions.ShareCachingTime;
			Name = _myTestConfig.Name;

		}

		public IndexModel( IOptionsMonitor<DefaultCachingOptions> cachingOptionsAccessor , IOptionsSnapshot<DefaultCachingOptions> optionsSnapshot, IOptionsSnapshot<TestConfig> testConfigSnapshot)
		{
			this._defaultCachingOptions = cachingOptionsAccessor.CurrentValue;
			this._snapshotOptions = optionsSnapshot.Value;
			this._myTestConfig = testConfigSnapshot.Value;
		}
	}
}
