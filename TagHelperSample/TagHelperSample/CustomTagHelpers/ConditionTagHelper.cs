using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSample.CustomTagHelpers
{
	/// <summary>
	/// Added to a div and renders the contents only if the condition is true
	/// </summary>
	[HtmlTargetElement("div", Attributes =nameof(Condition))]
	public class ConditionTagHelper : TagHelper
	{
		/// <summary>
		/// The condition. Must be a boolean value.
		/// </summary>
		public bool Condition { get; set; }

		/// <summary>
		/// Process the tag helper
		/// </summary>
		/// <param name="context">The context of the taghelper</param>
		/// <param name="output">the output of the element the taghelper is on</param>
		public override void Process( TagHelperContext context, TagHelperOutput output )
		{
			if ( !Condition )
			{
				output.SuppressOutput();
			}
		}


	}
}
