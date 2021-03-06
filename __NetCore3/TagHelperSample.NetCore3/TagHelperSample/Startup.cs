using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TagHelperSample
{
	public class Startup
	{
		#region Properties

		/// =================================================================================================================
		/// <summary>
		/// The configuration for the project
		/// </summary>
		/// =================================================================================================================
		public IConfiguration Configuration { get; }

		#endregion

		#region ConfigureServices

		/// =================================================================================================================
		/// <summary>
		/// Adds the different objects to the dependency injection. This method is called by the runtime. Add your own
		/// objects here, using the pattern used by microsoft.
		/// </summary>
		/// <param name="services">The collection of services for the dependency injection</param>
		/// =================================================================================================================
		public void ConfigureServices( IServiceCollection services )
		{
			services.Configure<CookiePolicyOptions>( options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			} );

			services.AddControllersWithViews();
		}

		#endregion

		#region Configure (the HTTP Request pipeline) 

		/// =================================================================================================================
		/// <summary>
		/// Configures the HTTP Request pipeline. Everything that needs to be used in the application (like middleware,
		/// routing, static files, memory-cache, etc.) needs to be added to the pipeline here
		/// </summary>
		/// <param name="app">An <see cref="IApplicationBuilder"/> object to add the functionalities to</param>
		/// <param name="env">
		/// The <see cref="IWebHostEnvironment"/> with the information about the environment the app is running in
		/// </param>
		/// =================================================================================================================
		public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
		{
			if ( env.IsDevelopment() )
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler( "/Home/Error" );
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints( endpoints =>
			 {
				 endpoints.MapControllerRoute(
					 name: "default",
					 pattern: "{controller=Home}/{action=Index}/{id?}" );
			 } );
		}

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		///  The constructor
		/// </summary>
		/// <param name="configuration">The configuration, automatically loaded and injected into the project</param>
		/// =================================================================================================================
		public Startup( IConfiguration configuration )
		{
			Configuration = configuration;
		}

		#endregion
	}
}
