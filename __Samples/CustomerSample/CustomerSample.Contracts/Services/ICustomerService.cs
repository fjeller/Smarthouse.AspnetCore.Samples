using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerSample.Contracts.Models;

namespace CustomerSample.Contracts.Services
{
	public interface ICustomerService
	{

		Task<CustomerModel> GetCustomerAsync( int id );

		Task<List<CustomerModel>> GetCustomersAsync();

		Task<bool> StoreCustomer( CustomerModel model );

	}
}
