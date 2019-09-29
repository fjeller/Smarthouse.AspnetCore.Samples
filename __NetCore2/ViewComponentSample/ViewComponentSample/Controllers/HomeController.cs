using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.DataContext;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers
{
	public class HomeController : Controller
	{
		private readonly DemoDataContext _demoContext;

		public HomeController( DemoDataContext demoContext )
		{
			_demoContext = demoContext;
			_demoContext.Database.EnsureCreated();
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
