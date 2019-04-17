using System;
using System.Collections.Generic;
using System.Text;
using DbSample.Business.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace DbSample.Business.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static void UsePageImpressions(this IApplicationBuilder app)
        {
            app.UseMiddleware<FactoryBasedPageImpressionsMiddleware>();
        }

    }
}
