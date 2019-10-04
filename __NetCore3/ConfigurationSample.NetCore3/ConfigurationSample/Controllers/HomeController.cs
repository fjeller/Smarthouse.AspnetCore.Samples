using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationSample.ConfigurationClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConfigurationSample.Models;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample.Controllers
{
	public class HomeController : Controller
	{
		#region Fields

		private readonly IConfiguration _configuration;

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="configuration">The configuration data from the system</param>
		/// =================================================================================================================
		public HomeController( IConfiguration configuration )
		{
			_configuration = configuration;
		}

		#endregion

		public IActionResult Index()
		{
			IndexModel model = new IndexModel()
			{
				CacheConfiguration = this._configuration.GetSection( "CacheConfiguration" ).Get<CacheConfiguration>(),
				DefaultIsinPrefix = this._configuration.GetSection( "Defaults" ).GetValue<string>( "IsinPrefix" ),
				DefaultNewsCount = this._configuration.GetSection( "Defaults" ).GetValue<int>( "NewsCount" ),
				DefaultPageSize = this._configuration.GetSection( "Defaults" ).GetValue<int>( "PageSize" )
			};

			//CacheConfiguration cacheConfiguration2 = new CacheConfiguration();
			//this._configuration.GetSection( "CacheConfiguration" ).Bind(cacheConfiguration2);

			//List<CacheConfigurationItem> cacheItems = this._configuration.GetSection("CacheConfiguration").Get<List<CacheConfigurationItem>>();

			return View( model );
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
