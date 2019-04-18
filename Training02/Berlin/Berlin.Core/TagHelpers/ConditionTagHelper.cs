using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Berlin.Core.TagHelpers
{
    [HtmlTargetElement("div", Attributes =nameof(Condition))]
    public class ConditionTagHelper : TagHelper
    {
        [HtmlAttributeName("condition")]
        public bool Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if ( !Condition )
            {
                output.SuppressOutput();
            }
        }

    }
}
