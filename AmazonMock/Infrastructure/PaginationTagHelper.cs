using AmazonMock.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AmazonMock.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]

    // inherit from taghelper
    public class PaginationTagHelper : TagHelper
    {
        // help build url
        private IUrlHelperFactory urlHelperFactory;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        // give info about view context
        [ViewContext]

        // makes attribute not bound to tag so person cannot type in it
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        // get what page user is on
        public string? PageAction { get; set; }

        public PaginationInfo PageModel { get; set; }

        // set up options in tag helper
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;
        public string PageClassNormal { get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    // build tag
                    TagBuilder tag = new TagBuilder("a");

                    // set href for tag
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);

                        // if tag is for current page, use the page class selected, if not use page class normal
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    // set inner html
                    tag.InnerHtml.Append(i.ToString());

                    // pass in tag
                    result.InnerHtml.AppendHtml(tag);
                }

                // append result to screen
                output.Content.AppendHtml(result.InnerHtml);

            }
        }
    }
}
