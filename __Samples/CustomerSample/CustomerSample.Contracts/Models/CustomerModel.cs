using System;
using System.Collections.Generic;
using System.Text;
using CustomerSample.Contracts.DataTransferObjects;

namespace CustomerSample.Contracts.Models
{
	public class CustomerModel
	{

		public int Id { get; set; }
		public string Lastname { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
		public bool IsActive { get; set; }

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

	}
}
