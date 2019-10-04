using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OptionsSample
{
	public class Program
	{
		public static void Main( string[] args )
		{
			CreateHostBuilder( args ).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder( string[] args )
		{
			return Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					string environmentName = hostingContext.HostingEnvironment.EnvironmentName;

					config.AddJsonFile("cachesettings.json", true, true);
					config.AddJsonFile($"cachesettings.{environmentName}.json");
					config.AddJsonFile("translationsettings.json");
					config.AddJsonFile($"translationsettings.{environmentName}.json");
				})
				.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
		}
	}
}
