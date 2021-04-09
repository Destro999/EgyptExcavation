using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class BiologicalSample
    {
        public string RackNumber { get; set; }
        public string BagNumber { get; set; }
        public string BurialId { get; set; }
        public string LowPairNs { get; set; }
        public string HighPairNs { get; set; }
        public string BurialLocationNs { get; set; }
        public string LowPairEw { get; set; }
        public string HighPairEw { get; set; }
        public string BurialLocationEw { get; set; }
        public string BurialSubplot { get; set; }
        public string BurialNumber { get; set; }
        public string ClusterNumber { get; set; }
        public string Date { get; set; }
        public string PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public string Initials { get; set; }
        public string Column17 { get; set; }
    }
}
