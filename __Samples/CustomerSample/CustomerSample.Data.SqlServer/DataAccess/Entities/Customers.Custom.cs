using System;
using System.Collections.Generic;
using System.Text;
using CustomerSample.Contracts.DataTransferObjects;

namespace CustomerSample.Data.SqlServer.DataAccess.Entities
{
	public partial class Customers
	{

		public CustomerData ToDto()
		{
			CustomerData result = new CustomerData()
			{
				Email = this.Email,
				FirstName = this.FirstName,
				Id = this.Id,
				IsActive = this.IsActive,
				Lastname = this.Lastname
			};

			return result;
		}

		public static Customers FromDto(CustomerData data)
		{
			Customers result = new Customers();
			result.MapFrom(data);

			return result;
		}

		public void MapFrom(CustomerData data)
		{
			Email = data.Email;
			FirstName = data.FirstName;
			IsActive = data.IsActive;
			Lastname = data.Lastname;
		}
	}
}
