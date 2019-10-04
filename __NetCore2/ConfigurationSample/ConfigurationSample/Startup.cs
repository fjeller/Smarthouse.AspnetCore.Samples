﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigurationSample
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


			services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 );
		}

		#endregion

		#region Configure( the HTTP Request pipeline )

		/// =================================================================================================================
		/// <summary>
		/// Configures the HTTP Request pipeline. Everything that needs to be used in the application (like middleware,
		/// routing, static files, memory-cache, etc.) needs to be added to the pipeline here
		/// </summary>
		/// <param name="app">An <see cref="IApplicationBuilder"/> object to add the functionalities to</param>
		/// <param name="env">
		/// The <see cref="IHostingEnvironment"/> with the information about the environment the app is running in
		/// </param>
		/// =================================================================================================================
		public void Configure( IApplicationBuilder app, IHostingEnvironment env )
		{
			if ( env.IsDevelopment() )
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler( "/Home/Error" );
			}

			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc( routes =>
			 {
				 routes.MapRoute(
					 name: "default",
					 template: "{controller=Home}/{action=Index}/{id?}" );
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
