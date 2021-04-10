using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class Filters
    {
        //Stores all the filters for the Burials
        public Filters (string filterString)
        {
            FilterString = filterString ?? "all-all-all-all-all-all-all";
            string[] filters = FilterString.Split('-');
            BurialSubplot = filters[0];
            Sex = filters[1];
            HairColor = filters[2];
            SampleTaken = filters[3];
            AgeCode = filters[4];
            HeadDirection = filters[5];
            YearFound = filters[6];
        }

        public string FilterString { get; set; }
        public string BurialSubplot { get; set; }
        public string Sex { get; set; }
        public string HairColor { get; set; }
        public string SampleTaken { get; set; }
        public string AgeCode { get; set; }
        public string HeadDirection { get; set; }
        public string YearFound { get; set; }

        public bool HasBurialSubplot => BurialSubplot.ToLower() != "all";
        public bool HasSex => Sex.ToLower() != "all";
        public bool HasHairColor => HairColor.ToLower() != "all";
        public bool HasSampleTaken => SampleTaken.ToLower() != "all";
        public bool HasAgeCode => AgeCode.ToLower() != "all";
        public bool HasHeadDirection => HeadDirection.ToLower() != "all";
        public bool HasYearFound => YearFound.ToLower() != "all";
    }
}
