using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsSample.Models
{
	public class FullNameModel
	{
		[Required]
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[Required]
		[DisplayName("Last Name")]
		public string LastName { get; set; }

		public DisplayNameModel DisplayName { get; set; }

	}
}
