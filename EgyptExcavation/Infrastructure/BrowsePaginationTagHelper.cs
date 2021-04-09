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

            // outputs all the buttons
            //for (int i = 1; i <= PageInfo.NumPages; i++)
            //{
            //    TagBuilder individualPageLink = new TagBuilder("a");
            //    KeyValuePairs["pageNum"] = i;
            //    // Creates Index action and passes route info from the KeyValuePairs dictionary
            //    individualPageLink.Attributes["href"] = urlHelp.Action("Index","Burials", KeyValuePairs);
            //    individualPageLink.InnerHtml.Append(i.ToString());

            //    // Style buttons and highlight selected
            //    if (PageClassesEnabled)
            //    {
            //        individualPageLink.AddCssClass(PageClass);
            //        individualPageLink.AddCssClass(i == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
            //    }

            //    finishedTag.InnerHtml.AppendHtml(individualPageLink);
            //    // Code belows adds line breaks so we can fit all 200 buttons lol.
            //    if (buttonLineBreaker >= 38)
            //    {
            //        finishedTag.InnerHtml.AppendHtml("<br>");
            //        buttonLineBreaker = 0;
            //    }
            //    else
            //    {
            //        buttonLineBreaker++;
            //    }
            //}

            // Jonah's experimental partial pagination

            // Add page one here, since we always want it to show up
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
                    i+= 2;
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

            output.Content.AppendHtml(finishedTag.InnerHtml);
        }

    }
}
