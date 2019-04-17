using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConfigurationSample
{
	public class Program
	{
		public static void Main( string[] args )
		{
			CreateWebHostBuilder( args ).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder( string[] args )
		{
			//return WebHost.CreateDefaultBuilder( args )
			//	.ConfigureAppConfiguration( ( hostingContext, config ) =>
			//	{
			//		IHostingEnvironment hostingEnvironment = hostingContext.HostingEnvironment;

			//		string environmentConfigFileName = $"test.{hostingEnvironment.EnvironmentName}.json";

			//		config.AddJsonFile( "test.json", true, true );
			//		config.AddJsonFile( environmentConfigFileName, true, true );
			//	} )
			//	.UseStartup<Startup>();

			return WebHost.CreateDefaultBuilder( args )
				.ConfigureAppConfiguration( ( hostingContext, config ) =>
				{
					IHostingEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
					string baseFile = "Configuration/test.json";
					string devFile = $"Configuration/{hostingEnvironment.EnvironmentName}/test.json";

                    config.AddJsonFile(baseFile, true, true );
					config.AddJsonFile( devFile, true, true );
                } )
				.UseStartup<Startup>();
		}
	}
}
