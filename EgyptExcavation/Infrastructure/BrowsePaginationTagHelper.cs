using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class BrowsePaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo { get; set; }



    }
}
