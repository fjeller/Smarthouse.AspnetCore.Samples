using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptionsSample.Models;
using OptionsSample.OptionsClasses;

namespace OptionsSample.Controllers
{
	public class HomeController : Controller
	{
		#region Fields

		private readonly TranslationOptions _translationOptions;
		private readonly CachingOptions _cachingOptions;
		private readonly ApplicationNameOptions _applicationNameOptions;

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="translationOptionsAccessor">The accessor for the translation options</param>
		/// <param name="cachingOptionsAccessor">The accessor for the caching options</param>
		/// <param name="applicationNameOptionsAccessor">The accessor for the applicationName options</param>
		/// =================================================================================================================
		public HomeController( 
			IOptionsMonitor<TranslationOptions> translationOptionsAccessor, 
			IOptionsMonitor<CachingOptions> cachingOptionsAccessor,
			IOptionsMonitor<ApplicationNameOptions> applicationNameOptionsAccessor)
		{
			this._translationOptions = translationOptionsAccessor.CurrentValue;
			this._cachingOptions = cachingOptionsAccessor.CurrentValue;
			this._applicationNameOptions = applicationNameOptionsAccessor.CurrentValue;
		}

		#endregion

		#region Views

		/// =================================================================================================================
		/// <summary>
		/// The index view
		/// </summary>
		/// <returns>The view for the index page of the application</returns>
		/// =================================================================================================================
		public IActionResult Index()
		{
			IndexModel model = new IndexModel();

			model.ApplicationName = this._applicationNameOptions.ApplicationName;
			
			List<string> cachingTimeStrings = this._cachingOptions.Items.Select(i => $"{i.Name}: {i.Hours}:{i.Minutes}:{i.Seconds}").ToList();
			model.CachingTimes.AddRange(cachingTimeStrings);

			model.Translations = this._translationOptions;

			return View(model);
		}

		/// =================================================================================================================
		/// <summary>
		/// The privacy view, not used in the sample
		/// </summary>
		/// <returns>The privacy view</returns>
		/// =================================================================================================================
		public IActionResult Privacy()
		{
			return View();
		}

		/// =================================================================================================================
		/// <summary>
		/// The error view, not used in the sample
		/// </summary>
		/// <returns>The error view</returns>
		/// =================================================================================================================
		[ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
		public IActionResult Error()
		{
			return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
		}

		#endregion
	}
}
