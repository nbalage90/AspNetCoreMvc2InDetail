using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ch24_UsingTheFormTagHelpers.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "wrap")]
    public class TableCellTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<b><i>");
            output.PostContent.SetHtmlContent("</i></b>");
        }
    }
}
