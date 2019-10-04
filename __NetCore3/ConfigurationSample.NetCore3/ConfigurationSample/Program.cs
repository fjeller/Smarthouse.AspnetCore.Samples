using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConfigurationSample
{
	public class Program
	{
		public static void Main( string[] args )
		{
			CreateHostBuilder( args ).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder( string[] args )
		{
			//return Host.CreateDefaultBuilder(args)
			//	.ConfigureAppConfiguration( ( hostingContext, config ) =>
			//	 {
			//		 IHostEnvironment hostingEnvironment = hostingContext.HostingEnvironment;

			//		 string environmentConfigFileName = $"cachesettings.{hostingEnvironment.EnvironmentName}.json";

			//		 config.AddJsonFile( "cachesettings.json", true, true );
			//		 config.AddJsonFile( environmentConfigFileName, true, true );
			//	 } )
			//	.ConfigureWebHostDefaults(webBuilder =>
			//	{
			//		webBuilder.UseStartup<Startup>();
			//	});

			return Host.CreateDefaultBuilder( args )
				.ConfigureAppConfiguration( ( hostingContext, config ) =>
				{
					IHostEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
					string baseFile = "Configuration/cachesettings.json";
					string devFile = $"Configuration/{hostingEnvironment.EnvironmentName}/cachesettings.json";

					config.AddJsonFile( baseFile, true, true );
					config.AddJsonFile( devFile, true, true );
				} )
				.ConfigureWebHostDefaults( webBuilder =>
				 {
					 webBuilder.UseStartup<Startup>();
				 } );

		}
	}
}
