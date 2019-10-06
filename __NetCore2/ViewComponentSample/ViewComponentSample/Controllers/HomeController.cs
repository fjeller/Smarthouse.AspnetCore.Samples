using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.DataContext;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers
{
	public class HomeController : Controller
	{

		#region Fields

		private readonly DemoDataContext _demoContext;

		#endregion

		#region View methods

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

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="demoContext">The dome data context for the application</param>
		/// =================================================================================================================
		public HomeController( DemoDataContext demoContext )
		{
			_demoContext = demoContext;
			_demoContext.Database.EnsureCreated();
		}

		#endregion

	}
}
