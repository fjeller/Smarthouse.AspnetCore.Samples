using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CustomerSample.Contracts.Models;
using CustomerSample.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerSample.Models;

namespace CustomerSample.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICustomerService _service;

		public HomeController(ICustomerService service)
		{
			_service = service;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult AddCustomer()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddCustomer(CustomerModel model)
		{
			bool isSuccessful = await this._service.StoreCustomer(model);
			string resultModel = isSuccessful ? 
				$"{model.FirstName} {model.Lastname}" : 
				null;

			return PartialView("Success", resultModel);
		}

		public IActionResult AddCustomer2()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddCustomer2( CustomerModel model )
		{
			await this._service.StoreCustomer( model );
			return RedirectToAction("AddCustomer2");
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
