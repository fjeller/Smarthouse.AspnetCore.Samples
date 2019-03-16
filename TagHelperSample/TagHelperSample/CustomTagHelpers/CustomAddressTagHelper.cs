using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelperSample.Models;

namespace TagHelperSample.CustomTagHelpers
{
	/// =================================================================================================================
	/// <summary>
	/// The Tag Helper naming follows conventions:
	/// - TagHelper is ommitted
	/// - Pascal-case is transformed into kebap-case
	/// Hence this tag helper is used on a page as <cookie-consent></cookie-consent>
	/// </summary>
	/// =================================================================================================================
	public class CustomAddressTagHelper : TagHelper 
	{
		/// <summary>
		/// The model with the data to display
		/// </summary>
		public AddressModel Model { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The method to create the HTML content
		/// </summary>
		/// <returns>The full HTML content to render</returns>
		/// =================================================================================================================
		private string CreateHtmlContent()
		{
			StringBuilder resultBuilder = new StringBuilder();
			resultBuilder.Append( $"{Model.Name}<br />" );
			resultBuilder.Append( $"{Model.Street}<br />" );
			resultBuilder.Append( $"{Model.ZipCode} {Model.City}<br />" );

			return resultBuilder.ToString();
		}

		/// =================================================================================================================
		/// <summary>
		/// The main process method / non-async
		/// </summary>
		/// <param name="context">The <see cref="TagHelperContext"/></param>
		/// <param name="output">The <see cref="TagHelperOutput"/>. This is the content rendered</param>
		/// =================================================================================================================
		public override void Process( TagHelperContext context, TagHelperOutput output )
		{
			string htmlContent = CreateHtmlContent();

			output.TagName = "address";
			output.Content.SetHtmlContent( htmlContent );
			output.TagMode = TagMode.StartTagAndEndTag;
		}

	}
}
