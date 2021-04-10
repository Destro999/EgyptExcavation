using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models.ViewModels
{
    // Because we need to pass both page numbering info and the _context database info to the Browse views,
    // we create this view model to bundle up all that info for the Home Controller.
    // -Jonah
    public class BrowseViewModel
    {
        // Not sure if a List or an IEnumerable is right here
        public IEnumerable<Burial> Burials { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }

        public IEnumerable<BiologicalSample> BiologicalSamples { get; set; }
        // Below, we will also want to include any filtering info that would be included in the URL route. EX from BowlingLeague-
        // public string TeamName { get; set; }
    }
}
