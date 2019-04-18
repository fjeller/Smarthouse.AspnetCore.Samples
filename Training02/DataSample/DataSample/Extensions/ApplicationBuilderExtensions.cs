using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSample.Middlewarez;
using Microsoft.AspNetCore.Builder;

namespace DataSample.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static void UsePageImpressions(this IApplicationBuilder app)
        {
            app.UseMiddleware<FactoryBasedPageImpressionsMiddleware>();
        }

    }
}
