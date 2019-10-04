using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MiddlewareSample.DataAccess.Context;
using MiddlewareSample.DataAccess.Entities;


namespace MiddlewareSample.Middleware
{
	/// <summary>
	/// Convention based middleware
	/// - Is only instantiated once
	/// - Is a singleton (and is automatically added as a singleton per Convention)
	/// - No injection of scoped services into constructor, instead into Invoke() / InvokeAsync()
	/// - Providing of parameters when the middleware is added to the system is possible
	/// </summary>
	public class PageImpressionsMiddleware
	{
		#region Fields 

		private readonly RequestDelegate _next;

		#endregion

		#region InvokeAsync

		public async Task InvokeAsync( HttpContext context, MiddlewareDataContext dataContext )
		{
			string ipAddress = context.Connection.RemoteIpAddress.ToString();
			PageImpression impression = await dataContext.PageImpressions.FirstOrDefaultAsync( c => c.IpAddress.Equals( ipAddress ) );
			if ( impression == null )
			{
				impression = new PageImpression
				{
					IpAddress = ipAddress
				};
				await dataContext.PageImpressions.AddAsync( impression );
			}

			impression.Count++;

			dataContext.SaveChanges();

			await _next( context );
		}

		#endregion

		#region Constructor

		public PageImpressionsMiddleware( RequestDelegate next )
		{
			this._next = next;
		}

		#endregion

	}
}
