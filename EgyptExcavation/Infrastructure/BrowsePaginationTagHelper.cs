using EgyptExcavation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Infrastructure
{
    // This class builds the buttons for the page navigation, particularly for browsing the Burial info!
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class BrowsePaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo { get; set; }
        public PageNumberingInfo PageInfo { get; set; }

        // Dictionary of key-value pairs for routing
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        // Constructor
        public BrowsePaginationTagHelper (IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelp = urlInfo.GetUrlHelper(ViewContext);
            TagBuilder finishedTag = new TagBuilder("div");
            int buttonLineBreaker = 0;
            bool iAdjusted = false;

            // Jonah's partial pagination

            // Add page one here if there is at least one item
            if (PageInfo.TotalNumItems > 0)
            {
                TagBuilder firstPageLink = new TagBuilder("a");
                KeyValuePairs["pageNum"] = 1;
                // Creates Index action and passes route info from the KeyValuePairs dictionary
                firstPageLink.Attributes["href"] = urlHelp.Action("Index", "Burials", KeyValuePairs);
                firstPageLink.InnerHtml.Append("1");

                // Style buttons and highlight selected
                if (PageClassesEnabled)
                {
                    firstPageLink.AddCssClass(PageClass);
                    firstPageLink.AddCssClass(PageInfo.CurrentPage == 1 || PageInfo.CurrentPage == 0 ? PageClassSelected : PageClassNormal);
                }

                finishedTag.InnerHtml.AppendHtml(firstPageLink);
            }
            

            // Only want to print more buttons if we have more than 1 page!
            if (PageInfo.NumPages > 1)
            {
                //Only need to loop through middle buttons if we have more than two buttons. Otherwise, printing the first and last button will suffice.
                if (PageInfo.NumPages > 2)
                {
                    // For loop to populate pages around current page
                    for (int i = PageInfo.CurrentPage - 1; i <= PageInfo.CurrentPage + 10 && i <= PageInfo.NumPages - 1; i++)
                    {
                        // If we are on page 1, don't want to list the previous page
                        if (PageInfo.CurrentPage == 0 && !iAdjusted)
                        {
                            i += 3;
                            iAdjusted = true;
                        }
                        else if (PageInfo.CurrentPage == 1 && !iAdjusted)
                        {
                            i += 2;
                            iAdjusted = true;
                        }
                        else if (PageInfo.CurrentPage == 2 && !iAdjusted)
                        {
                            i++;
                            iAdjusted = true;
                        }
                        else if (PageInfo.CurrentPage != 3 && !iAdjusted)
                        {
                            TagBuilder elipsesTag = new TagBuilder("a");
                            elipsesTag.InnerHtml.Append(".....");
                            finishedTag.InnerHtml.AppendHtml(elipsesTag);
                            iAdjusted = true;
                        }

                        TagBuilder individualPageLink = new TagBuilder("a");
                        KeyValuePairs["pageNum"] = i;
                        // Creates Index action and passes route info from the KeyValuePairs dictionary
                        individualPageLink.Attributes["href"] = urlHelp.Action("Index", "Burials", KeyValuePairs);
                        individualPageLink.InnerHtml.Append(i.ToString());

                        // Style buttons and highlight selected
                        if (PageClassesEnabled)
                        {
                            individualPageLink.AddCssClass(PageClass);
                            individualPageLink.AddCssClass(i == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                        }

                        finishedTag.InnerHtml.AppendHtml(individualPageLink);
                    }
                }
                
                

                // Add last page here
                int lastPageNum = PageInfo.NumPages;
                TagBuilder lastPageLink = new TagBuilder("a");
                KeyValuePairs["pageNum"] = lastPageNum;
                // Creates Index action and passes route info from the KeyValuePairs dictionary
                lastPageLink.Attributes["href"] = urlHelp.Action("Index", "Burials", KeyValuePairs);
                lastPageLink.InnerHtml.Append(lastPageNum.ToString());

                // Style buttons and highlight selected
                if (PageClassesEnabled)
                {
                    lastPageLink.AddCssClass(PageClass);
                    lastPageLink.AddCssClass(PageInfo.NumPages == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                if (PageInfo.CurrentPage <= PageInfo.NumPages - 10)
                {
                    TagBuilder elipsesTag = new TagBuilder("a");
                    elipsesTag.InnerHtml.Append(".....");
                    finishedTag.InnerHtml.AppendHtml(elipsesTag);
                }
                finishedTag.InnerHtml.AppendHtml(lastPageLink);
            }

            
            

            output.Content.AppendHtml(finishedTag.InnerHtml);
        }

    }
}
