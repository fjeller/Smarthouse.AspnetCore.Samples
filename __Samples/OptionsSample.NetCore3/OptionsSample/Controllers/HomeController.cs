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

		private readonly TranslationOptions _translations;
		private readonly CacheOptions _cacheOptions;

		public HomeController( 
			IOptionsMonitor<TranslationOptions> translationsAccessor, 
			IOptionsMonitor<CacheOptions> cacheOptionsAccessor )
		{
			this._translations = translationsAccessor.CurrentValue;
			this._cacheOptions = cacheOptionsAccessor.CurrentValue;
		}

		public IActionResult Index()
		{


			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
		public IActionResult Error()
		{
			return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
		}
	}
}
