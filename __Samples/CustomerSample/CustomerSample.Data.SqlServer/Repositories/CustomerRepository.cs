using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerSample.Contracts.DataTransferObjects;
using CustomerSample.Contracts.Repositories;
using CustomerSample.Data.SqlServer.DataAccess.Context;
using CustomerSample.Data.SqlServer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerSample.Data.SqlServer.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		#region Fields

		private readonly SampleDataContext _dataContext;

		#endregion

		public async Task<CustomerData> GetCustomerAsync(int id)
		{
			Customers currentCustomer = await this._dataContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
			CustomerData result = currentCustomer?.ToDto();

			return result;
		}

		public async Task<List<CustomerData>> GetCustomersAsync()
		{
			List<Customers> customers = await this._dataContext.Customers
				.OrderBy(c => c.Lastname)
				.ThenBy(c => c.FirstName)
				.ToListAsync();

			List<CustomerData> result = customers
				.Select(c => c.ToDto()).ToList();

			return result;
		}

		public async Task<bool> StoreCustomer(CustomerData data)
		{
			return data.Id > 0 ? 
				await UpdateCustomer(data) : 
				await InsertCustomer(data);
		}

		private async Task<bool> InsertCustomer(CustomerData data)
		{
			Customers newCustomer = Customers.FromDto(data);
			this._dataContext.Customers.Add(newCustomer);
			int result = await this._dataContext.SaveChangesAsync();

			return result==1;
		}

		private async Task<bool> UpdateCustomer( CustomerData data )
		{
			Customers currentCustomer = await this._dataContext
				.Customers
				.FirstOrDefaultAsync(c => c.Id == data.Id);

			if (currentCustomer == null)
			{
				return false;
			}

			currentCustomer.MapFrom(data);
			await this._dataContext.SaveChangesAsync();

			return true;
		}

		#region Constructor

		public CustomerRepository( SampleDataContext dataContext )
		{
			this._dataContext = dataContext;
		}

		#endregion

	}
}
