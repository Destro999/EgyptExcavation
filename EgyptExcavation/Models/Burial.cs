using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Burial
    {
        public string BurialId { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }
        public string LowPairNs { get; set; }
        public string HighPairNs { get; set; }
        public string LowPairEw { get; set; }
        public string HighPairEw { get; set; }
        public string BurialSubplot { get; set; }
        public string BurialDepth { get; set; }
        public string SouthToHead { get; set; }
        public string SouthToFeet { get; set; }
        public string WestToHead { get; set; }
        public string WestToFeet { get; set; }
        public string BurialSituation { get; set; }
        public string LengthOfRemainsMeters { get; set; }
        public string LengthOfRemainsCentimeters { get; set; }
        public string BurialNumber { get; set; }
        public string SampleNumber { get; set; }
        public string GenderGe { get; set; }
        public string GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string SexMethod { get; set; }
        public string BasilarSuture { get; set; }
        public string VentralArc { get; set; }
        public string SubpubicAngle { get; set; }
        public string SciaticNotch { get; set; }
        public string PubicBone { get; set; }
        public string PreaurSulcus { get; set; }
        public string MedialIpRamus { get; set; }
        public string DorsalPitting { get; set; }
        public string ForamanMagnum { get; set; }
        public string FemurHead { get; set; }
        public string HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public string FemurLength { get; set; }
        public string HumerusLength { get; set; }
        public string TibiaLength { get; set; }
        public string Robust { get; set; }
        public string SupraorbitalRidges { get; set; }
        public string OrbitEdge { get; set; }
        public string ParietalBossing { get; set; }
        public string Gonian { get; set; }
        public string NuchalCrest { get; set; }
        public string ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public string MaximumCranialLength { get; set; }
        public string MaximumCranialBreadth { get; set; }
        public string BasionBregmaHeight { get; set; }
        public string BasionNasion { get; set; }
        public string BasionProsthionLength { get; set; }
        public string BizygomaticDiameter { get; set; }
        public string NasionProsthion { get; set; }
        public string MaximumNasalBreadth { get; set; }
        public string InterorbitalBreadth { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public string SampleTaken { get; set; }
        public string HairTaken { get; set; }
        public string SoftTissueTaken { get; set; }
        public string BoneTaken { get; set; }
        public string ToothTaken { get; set; }
        public string TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public string ArtifactFound { get; set; }
        public string EstimateAge { get; set; }
        public string AgeMethod { get; set; }
        public string AgeCode { get; set; }
        public string EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public string YearFound { get; set; }
        public string MonthFound { get; set; }
        public string DayFound { get; set; }
        public string HeadDirection { get; set; }
        public string Gamous { get; set; }
        public string BurialIcon { get; set; }
        public long? BurialIcon2 { get; set; }
        public string BurialPreservation { get; set; }
        [Key]
        public int BurialIdInt { get; set; }
        public long HasPhoto { get; set; }

        public bool HasPhotoMethod()
        {
            if (HasPhoto == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetPhotoPath()
        {
            return this.BurialIdInt.ToString() + ".jpg";
        }
    }
}
