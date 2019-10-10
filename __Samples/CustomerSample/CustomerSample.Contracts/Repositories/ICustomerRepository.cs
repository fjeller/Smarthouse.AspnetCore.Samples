using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerSample.Contracts.DataTransferObjects;

namespace CustomerSample.Contracts.Repositories
{
	public interface ICustomerRepository
	{

		Task<CustomerData> GetCustomerAsync(int id);

		Task<List<CustomerData>> GetCustomersAsync();

		Task<bool> StoreCustomer(CustomerData data);

	}
}
