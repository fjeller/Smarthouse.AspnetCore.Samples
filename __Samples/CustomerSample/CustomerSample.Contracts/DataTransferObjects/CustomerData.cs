using System;
using System.Collections.Generic;
using System.Text;
using CustomerSample.Contracts.Models;

namespace CustomerSample.Contracts.DataTransferObjects
{
	public class CustomerData
	{

		public int Id { get; set; }
		public string Lastname { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
		public bool IsActive { get; set; }

		public CustomerModel ToModel()
		{
			CustomerModel result = new CustomerModel()
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
