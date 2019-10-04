using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareSample.Middleware;

namespace MiddlewareSample.Extensions
{
	public static class CustomMiddlewareExtensions
	{
		/// <summary>
		/// Adds the convention based middleware to the system and uses it. Only the UseXxx()-method is
		/// needed, no AddXxx()-method, since the convention based middelware is automatically added as a
		/// singleton
		/// </summary>
		/// <param name="builder">The <see cref="IApplicationBuilder"/> object</param>
		/// <returns>The <see cref="IApplicationBuilder"/> object with the added middelware</returns>
		public static IApplicationBuilder UsePageImpressionsMiddleware( this IApplicationBuilder builder )
		{
			return builder.UseMiddleware<PageImpressionsMiddleware>();
		}

		/// <summary>
		/// Uses the factory based middleware. The middleware needs to be added to the DI before using it,
		/// since you can decide for yourself if this middleware is a singleton, scoped or transient.
		/// Factory based middleware must implement the IMiddleware interface
		/// </summary>
		/// <param name="builder">The <see cref="IApplicationBuilder"/> object</param>
		/// <returns>The <see cref="IApplicationBuilder"/> object with the added middelware</returns>
		public static IApplicationBuilder UseFactoryActivatedPageImpressionsMiddleware( this IApplicationBuilder builder )
		{
			return builder.UseMiddleware<FactoryActivatedPageImpressionsMiddleware>();
		}

		/// <summary>
		/// Adds the factory activated middleware as a scoped service to the DI
		/// </summary>
		/// <param name="services">The service collection of the DI</param>
		/// <returns>The service collection of the DI to add more stuff</returns>
		public static IServiceCollection AddFactoryActivatedPageImpressionsMiddleware( this IServiceCollection services )
		{
			return services.AddScoped<FactoryActivatedPageImpressionsMiddleware>();
		}

	}
}
