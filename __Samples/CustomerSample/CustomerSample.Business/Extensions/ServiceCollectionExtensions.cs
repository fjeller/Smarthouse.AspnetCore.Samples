using System;
using System.Collections.Generic;
using System.Text;
using CustomerSample.Business.Services;
using CustomerSample.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CustomerSample.Business.Extensions
{
	public static class ServiceCollectionExtensions
	{

		public static IServiceCollection AddBusinessServices(this IServiceCollection services)
		{
			services.TryAddScoped<ICustomerService, CustomerService>();

			return services;
		}

	}
}
