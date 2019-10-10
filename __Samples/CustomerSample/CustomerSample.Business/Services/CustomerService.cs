using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerSample.Contracts.DataTransferObjects;
using CustomerSample.Contracts.Models;
using CustomerSample.Contracts.Repositories;
using CustomerSample.Contracts.Services;

namespace CustomerSample.Business.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _repository;



		public async Task<CustomerModel> GetCustomerAsync(int id)
		{
			CustomerData customer = await this._repository.GetCustomerAsync(id);

			// Do something with it

			CustomerModel result = customer.ToModel();

			return result;
		}

		public async Task<List<CustomerModel>> GetCustomersAsync()
		{
			List<CustomerData> customers = await this._repository.GetCustomersAsync();
			List<CustomerModel> result = customers.Select(c => c.ToModel()).ToList();

			return result;
		}

		public async Task<bool> StoreCustomer(CustomerModel model)
		{
			CustomerData customer = model.ToDto();
			return await this._repository.StoreCustomer(customer);
		}

		public CustomerService( ICustomerRepository repository )
		{
			_repository = repository;
		}
	}
}
