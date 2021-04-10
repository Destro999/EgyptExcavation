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

        //Dictionaries to match DB values to what appears in the filters
        public static Dictionary<string, string> SexFilterValues =>
            new Dictionary<string, string>
            {
                {"S", "Sub-Adult" },
                {"C", "Child" },
                {"M", "Male" },
                {"F", "Female" },
                {"U", "Unknown" }
            };

        public static Dictionary<string, string> HairColorFilterValues =>
            new Dictionary<string, string>
            {
                {"B", "Brown" },
                {"R", "Red" },
                {"K", "Black" },
                {"D", "Blonde" },
                {"A", "Red/Brown" },
                {"U", "Unknown" }
            };
        public static Dictionary<string, string> SampleTakenFilterValues =>
            new Dictionary<string, string>
            {
                {"FALSE", "False" },
                {"TRUE", "True" },
                {"", "Blank" },

            };
        public static Dictionary<string, string> AgeCodeFilterValues =>
            new Dictionary<string, string>
            {
                {"N", "Newborn (0-1)" },
                {"I", "Infant (1-3)" },
                {"IN", "Infant (1-3)" },
                {"C", "Child (3-15)" },
                {"A", "Adult (15+)" },
                {"U", "Unknown" }

            };
        public static Dictionary<string, string> HeadDirectionFilterValues =>
            new Dictionary<string, string>
            {
                {"W", "West" },
                {"E", "East" },
                {"U", "Unknown" },
                {"", "Blank" }
            };
    }
}
