using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BerlinSample.Core.DataClasses;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BerlinSample.Core.MyOwnTagHelpers
{
    public class CustomAddressTagHelper : TagHelper
    {

        public AddressData Model { get; set; }

        /// =================================================================================================================
        /// <summary>
        /// The method to create the HTML content
        /// </summary>
        /// <returns>The full HTML content to render</returns>
        /// =================================================================================================================
        private string CreateHtmlContent()
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.Append($"{Model.FirstName} {Model.LastName}<br />");
            resultBuilder.Append($"{Model.Street}<br />");
            resultBuilder.Append($"{Model.ZipCode} {Model.City}<br />");

            return resultBuilder.ToString();
        }

        /// =================================================================================================================
        /// <summary>
        /// The main process method / non-async
        /// </summary>
        /// <param name="context">The <see cref="TagHelperContext"/></param>
        /// <param name="output">The <see cref="TagHelperOutput"/>. This is the content rendered</param>
        /// =================================================================================================================
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string htmlContent = CreateHtmlContent();

            output.TagName = "div";
            output.Content.SetHtmlContent(htmlContent);
            output.TagMode = TagMode.StartTagAndEndTag;
        }

    }
}
