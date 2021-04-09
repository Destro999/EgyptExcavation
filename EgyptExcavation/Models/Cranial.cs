using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Cranial
    {
        public string SampleNumber { get; set; }
        public string BurialId { get; set; }
        public double MaximumCranialLength { get; set; }
        public double MaximumCranialBreadth { get; set; }
        public double BasionBregmaHeight { get; set; }
        public double BasionNasion { get; set; }
        public double BasionProsthionLength { get; set; }
        public double BizygomaticDiameter { get; set; }
        public double NasionProsthion { get; set; }
        public double MaximumNasalBreadth { get; set; }
        public double InterorbitalBreadth { get; set; }
        public string LowHighPairNs { get; set; }
        public string BurialLocationNs { get; set; }
        public string LowHighPairEw { get; set; }
        public string BurialPositioningEastWestDirection { get; set; }
        public string BurialNumer { get; set; }
        public string BurialDepth { get; set; }
        public string BurialSubPlotDirection { get; set; }
        public string BurialArtifactDescription { get; set; }
        public byte[] BuriedWithArtifacts { get; set; }
        public string GilesGender { get; set; }
        public string BodyGender { get; set; }
    }
}
