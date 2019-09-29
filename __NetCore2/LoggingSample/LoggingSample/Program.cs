using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace LoggingSample
{
	public class Program
	{

		/// =======================================================================================================
		/// <summary>
		/// Configures the services. Adds the services to the dependency injection. This is the place where all
		/// objects should be added to the dependency injection. However, tooling is provided to enable us to
		/// add objects everywhere in the application.
		/// This method is called automatically by the runtime.
		/// </summary>
		/// <param name="services">The service collection to add the services to</param>
		/// =======================================================================================================
		public static void Main( string[] args )
		{
			Logger logger = NLogBuilder.ConfigureNLog( "nlog.config" ).GetCurrentClassLogger();
			try
			{
				logger.Info( "initialize Component Web - Main function" );
				CreateWebHostBuilder( args ).Build().Run();
			}
			catch ( Exception ex )
			{
				logger.Error( ex, "Error in main function, shutting down" );
				throw;
			}
			finally
			{
				LogManager.Shutdown();
			}
		}

		/// =======================================================================================================
		/// <summary>
		/// Creates a default web host, using the <see cref="Startup"/> class as the startup object and adding
		/// the appSettings.json and appSettings.{environment}.json files to the configuration
		/// </summary>
		/// <param name="args">The command line arguments for the application</param>
		/// <returns>An object implementing <see cref="IWebHostBuilder"/></returns>
		/// =======================================================================================================
		public static IWebHostBuilder CreateWebHostBuilder( string[] args )
		{
			return WebHost.CreateDefaultBuilder( args )
				.UseStartup<Startup>()
				.ConfigureLogging( logging =>
				{
					logging.ClearProviders();
					logging.SetMinimumLevel( LogLevel.Information );
				} )
				.UseNLog();
		}
	}
}
