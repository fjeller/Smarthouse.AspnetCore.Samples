using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OptionsSample
{
	public class Program
	{
		public static void Main( string[] args )
		{
			CreateWebHostBuilder( args ).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder( string[] args )
		{
			return WebHost.CreateDefaultBuilder( args )
				.ConfigureAppConfiguration(config => config.AddJsonFile("testconfig.json", true, true))
				.UseStartup<Startup>();
		}
	}
}
