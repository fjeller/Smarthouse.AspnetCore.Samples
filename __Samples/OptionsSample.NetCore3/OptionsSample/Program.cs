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

		public static IHostBuilder CreateHostBuilder( string[] args ) =>
			Host.CreateDefaultBuilder( args )
				.ConfigureAppConfiguration( ( hostingContext, config ) =>
				{

					string environment = hostingContext.HostingEnvironment.EnvironmentName;

					config.AddJsonFile("cachesettings.json", true, true);
					config.AddJsonFile( $"cachesettings.{environment}.json", true, true );
					config.AddJsonFile( "translationsettings.json", true, true );
					config.AddJsonFile( $"translationsettings.{environment}.json", true, true );

				} )
				.ConfigureWebHostDefaults( webBuilder =>
				 {
					 webBuilder.UseStartup<Startup>();
				 } );
	}
}
