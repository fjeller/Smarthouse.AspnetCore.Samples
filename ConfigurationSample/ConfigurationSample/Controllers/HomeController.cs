﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfigurationSample.Models;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample.Controllers
{
	public class HomeController : Controller
	{

		#region properties

		private IConfiguration Configuration { get; }

		#endregion


		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult TestView()
		{
			TestViewModel model = new TestViewModel();
			Configuration.GetSection( "testsection" ).Bind( model );

			//TestViewModel model = new TestViewModel()
			//{
			//	FirstWord = Configuration.GetSection( "testsection" ).GetValue<string>( "testvalue1" ),
			//	SecondWord = Configuration.GetSection( "testsection" ).GetValue<string>( "testvalue2" )
			//};

			return View( model );
		}


		[ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
		public IActionResult Error()
		{
			return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
		}

		public HomeController( IConfiguration configuration )
		{
			Configuration = configuration;
		}
	}
}
