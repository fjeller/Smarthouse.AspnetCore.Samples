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

                    string baseFile2 = "Configuration/test2.json";
                    string devFile2 = $"Configuration/{hostingEnvironment.EnvironmentName}/test2.json";

                    config.AddJsonFile(baseFile, true, true );
					config.AddJsonFile( devFile, true, true );
                    config.AddJsonFile(baseFile2, true, true);
                    config.AddJsonFile(devFile2, true, true);
                } )
				.UseStartup<Startup>();
		}
	}
}
