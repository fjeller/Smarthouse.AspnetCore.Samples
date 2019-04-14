﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsSample.Models
{
	public class EnterNameModel
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

	}
}
