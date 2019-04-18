using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Berlin.Core.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperContent content = await output.GetChildContentAsync();
            output.TagName = "a";
            output.Attributes.Add("href", "mailto:" + content.GetContent());
            output.TagMode = TagMode.StartTagAndEndTag;
        }

    }
}
