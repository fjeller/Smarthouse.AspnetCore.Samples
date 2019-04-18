using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSample.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataSample.Middlewarez
{
    public class PageImpressionsMiddleware
    {

        private RequestDelegate _next;

        public PageImpressionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, TodoDataContext dataContext)
        {
            string ipAddress = context.Connection.RemoteIpAddress.ToString();
            PageImpression impression = await dataContext
                .PageImpressions
                .FirstOrDefaultAsync(i => i.IpAddress.Equals(ipAddress, StringComparison.OrdinalIgnoreCase));

            if ( impression == null )
            {
                impression = new PageImpression()
                {
                    IpAddress = ipAddress,
                    Count = 0
                };
                await dataContext.PageImpressions.AddAsync(impression);
            }

            impression.Count++;
            await dataContext.SaveChangesAsync();

            await _next(context);
        }

    }
}
