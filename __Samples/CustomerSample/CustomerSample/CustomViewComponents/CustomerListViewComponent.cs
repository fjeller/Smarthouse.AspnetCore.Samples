using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSample.Contracts.Models;
using CustomerSample.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSample.CustomViewComponents
{
	public class CustomerListViewComponent : ViewComponent
	{

		private readonly ICustomerService _service;

		public CustomerListViewComponent(ICustomerService service)
		{
			_service = service;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<CustomerModel> model = await this._service.GetCustomersAsync();
			return model.Count > 5 ? View("Large", model) : View(model);
		}


	}
}
