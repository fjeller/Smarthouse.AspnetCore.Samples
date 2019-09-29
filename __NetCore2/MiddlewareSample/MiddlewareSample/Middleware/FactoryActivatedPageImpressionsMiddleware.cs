using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MiddlewareSample.DataAccess.DataAccess;

namespace MiddlewareSample.Middleware
{
	/// <summary>
	/// Factory Activated Middleware
	/// - Is not automatically added to the Dependency Injection Container, since it can be scoped or transient
	/// - Cannot take any parameters (while the convention based middelware can)
	/// - Can take scoped services (or basically any services) in the constructor
	/// - The RequestDelegate "next" is automatically provided to the InvokeAsync()-method
	/// </summary>
	public class FactoryActivatedPageImpressionsMiddleware : IMiddleware
	{
		#region fields

		private readonly MiddlewareSampleContext _dataContext;

		#endregion

		/// <summary>Request handling method.</summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Http.HttpContext" /> for the current request.</param>
		/// <param name="next">The delegate representing the remaining middleware in the request pipeline.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the execution of this middleware.</returns>
		public async Task InvokeAsync( HttpContext context, RequestDelegate next )
		{
			string ipAddress = context.Connection.RemoteIpAddress.ToString();
			PageImpression impression = await this._dataContext.PageImpressions.FirstOrDefaultAsync( c => c.IpAddress.Equals( ipAddress ) );
			if ( impression == null )
			{
				impression = new PageImpression
				{
					IpAddress = ipAddress
				};
				await this._dataContext.PageImpressions.AddAsync( impression );
			}

			impression.Count++;

			await this._dataContext.SaveChangesAsync();

			await next( context );
		}

		public FactoryActivatedPageImpressionsMiddleware( MiddlewareSampleContext dataContext )
		{
			this._dataContext = dataContext;
		}
	}
}
