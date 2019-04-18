using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSample.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataSample.Middlewarez
{
    public class FactoryBasedPageImpressionsMiddleware : IMiddleware
    {
        private readonly TodoDataContext _dataContext;

        public FactoryBasedPageImpressionsMiddleware(TodoDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string ipAddress = context.Connection.RemoteIpAddress.ToString();
            PageImpression impression = await this._dataContext
                .PageImpressions
                .FirstOrDefaultAsync(i => i.IpAddress.Equals(ipAddress, StringComparison.OrdinalIgnoreCase));

            if (impression == null)
            {
                impression = new PageImpression()
                {
                    IpAddress = ipAddress,
                    Count = 0
                };
                await this._dataContext.PageImpressions.AddAsync(impression);
            }

            impression.Count++;
            await this._dataContext.SaveChangesAsync();

            await next(context);
        }
    }
}
