using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DbSample.Data.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DbSample.Business.Middlewares
{
    public class FactoryBasedPageImpressionsMiddleware : IMiddleware
    {
        private readonly TodoDbContext _dataContext;

        public FactoryBasedPageImpressionsMiddleware(TodoDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string ipAddress = context.Connection.RemoteIpAddress.ToString();
            PageImpression impression = await this._dataContext.PageImpressions.FirstOrDefaultAsync(c => c.IpAddress.Equals(ipAddress));
            if (impression == null)
            {
                impression = new PageImpression
                {
                    IpAddress = ipAddress
                };
                await this._dataContext.PageImpressions.AddAsync(impression);
            }

            impression.Count++;

            this._dataContext.SaveChanges();

            await next(context);
        }
    }
}
