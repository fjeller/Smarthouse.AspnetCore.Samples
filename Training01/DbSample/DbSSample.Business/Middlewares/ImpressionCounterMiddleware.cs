using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DbSample.Data.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DbSample.Business.Middlewares
{
    public class ImpressionCounterMiddleware
    {

        private readonly RequestDelegate _next;

        public ImpressionCounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, TodoDbContext dataContext)
        {
            string ipAddress = context.Connection.RemoteIpAddress.ToString();
            PageImpression impression = await dataContext.PageImpressions.FirstOrDefaultAsync(c => c.IpAddress.Equals(ipAddress));
            if (impression == null)
            {
                impression = new PageImpression
                {
                    IpAddress = ipAddress
                };
                await dataContext.PageImpressions.AddAsync(impression);
            }

            impression.Count++;

            dataContext.SaveChanges();

            await _next(context);
        }

    }
}
