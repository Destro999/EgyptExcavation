using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{

    // This class contains the page information that feeds the Pagination Tag Helpers, so we can include buttons to
    // different number of pages and have the site remember how many pages we need and which page we are on.
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        // Calculates total number of pages
        public int NumPages => (int)(Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage));
    }
}
