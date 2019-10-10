using System;
using System.Collections.Generic;
using System.Text;
using CustomerSample.Contracts.Repositories;
using CustomerSample.Data.SqlServer.DataAccess.Context;
using CustomerSample.Data.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CustomerSample.Data.SqlServer.Extensions
{
	public static class ServiceCollectionExtensions
	{

		public static IServiceCollection AddDataAccess(
			this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<SampleDataContext>(
				options => options.UseSqlServer( connectionString ) );
			services.TryAddScoped<ICustomerRepository, CustomerRepository>();

			return services;
		}

	}
}
