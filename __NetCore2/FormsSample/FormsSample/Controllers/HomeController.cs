using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormsSample.Models;

namespace FormsSample.Controllers
{
	public class HomeController : Controller
	{
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

		public IActionResult EnterNameNormal()
		{
			return View();
		}

		public IActionResult EnterNameAjax()
		{
			return View();
		}

		public IActionResult EnterNameJavascript()
		{
			return View();
		}

		public IActionResult SaveNameNormal( FullNameModel model )
		{
			FullNameModel newModel = new FullNameModel()
			{
				FirstName = " ",
				LastName = " ",
				DisplayName = new DisplayNameModel()
				{
					FirstName = model.FirstName,
					LastName = model.LastName
				}
			};

			return View( "EnterNameNormal", newModel );
		}

		public IActionResult SaveNameAjax( EnterNameModel model )
		{
			DisplayNameModel newModel = new DisplayNameModel()
			{
				FirstName = model.FirstName,
				LastName = model.LastName
			};

			return PartialView( "_DisplayName", newModel );
		}

		public IActionResult SaveNameJavascript( EnterNameModel model )
		{
			return Json( new {firstName = model.FirstName, lastName = model.LastName} );
		}

	}
}
