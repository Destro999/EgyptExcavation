using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class EgyptContext : DbContext
    {
        public EgyptContext()
        {
        }

        public EgyptContext(DbContextOptions<EgyptContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BiologicalSample> BiologicalSample { get; set; }
        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<C14> C14 { get; set; }
        public virtual DbSet<Cranial> Cranial { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source = Egypt.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiologicalSample>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BagNumber)
                    .HasColumnName("bag_number")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialId)
                    .HasColumnName("Burial_Id")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialLocationEw)
                    .HasColumnName("burial_location_EW")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialLocationNs)
                    .HasColumnName("burial_location_NS")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialNumber)
                    .HasColumnName("burial_number")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasColumnType("ntext");

                entity.Property(e => e.ClusterNumber)
                    .HasColumnName("cluster_number")
                    .HasColumnType("ntext");

                entity.Property(e => e.Column17)
                    .HasColumnName("column17")
                    .HasColumnType("ntext");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("ntext");

                entity.Property(e => e.HighPairEw)
                    .HasColumnName("high_pair_EW")
                    .HasColumnType("ntext");

                entity.Property(e => e.HighPairNs)
                    .HasColumnName("high_pair_NS")
                    .HasColumnType("ntext");

                entity.Property(e => e.Initials)
                    .HasColumnName("initials")
                    .HasColumnType("ntext");

                entity.Property(e => e.LowPairEw)
                    .HasColumnName("low_pair_EW")
                    .HasColumnType("ntext");

                entity.Property(e => e.LowPairNs)
                    .HasColumnName("low_pair_NS")
                    .HasColumnType("ntext");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("ntext");

                entity.Property(e => e.PreviouslySampled)
                    .HasColumnName("previously_sampled")
                    .HasColumnType("ntext");

                entity.Property(e => e.RackNumber)
                    .HasColumnName("rack_number")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Burial>(entity =>
            {
                entity.Property(e => e.BurialId)
                    .HasColumnName("Burial_ID")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.AgeCode)
                    .HasColumnName("age_code")
                    .HasColumnType("ntext");

                entity.Property(e => e.AgeMethod)
                    .HasColumnName("age_method")
                    .HasColumnType("ntext");

                entity.Property(e => e.ArtifactFound)
                    .HasColumnName("artifact_found")
                    .HasColumnType("ntext");

                entity.Property(e => e.ArtifactsDescription)
                    .HasColumnName("artifacts_description")
                    .HasColumnType("ntext");

                entity.Property(e => e.BasilarSuture)
                    .HasColumnName("basilar_suture")
                    .HasColumnType("ntext");

                entity.Property(e => e.BasionBregmaHeight)
                    .HasColumnName("basion_bregma_height")
                    .HasColumnType("ntext");

                entity.Property(e => e.BasionNasion)
                    .HasColumnName("basion_nasion")
                    .HasColumnType("ntext");

                entity.Property(e => e.BasionProsthionLength)
                    .HasColumnName("basion_prosthion_length")
                    .HasColumnType("ntext");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasColumnName("bizygomatic_diameter")
                    .HasColumnType("ntext");

                entity.Property(e => e.BoneTaken)
                    .HasColumnName("bone_taken")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialDepth)
                    .HasColumnName("burial_depth")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialIcon)
                    .HasColumnName("burial_icon")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialIcon2)
                    .HasColumnName("burial_icon2")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialLocationEw)
                    .HasColumnName("burial_location_EW")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialLocationNs)
                    .HasColumnName("burial_location_NS")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialNumber)
                    .HasColumnName("burial_number")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialPreservation)
                    .HasColumnName("burial_preservation")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialSituation)
                    .HasColumnName("burial_situation")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasColumnType("ntext");

                entity.Property(e => e.CranialSuture)
                    .HasColumnName("cranial_suture")
                    .HasColumnType("ntext");

                entity.Property(e => e.DayFound)
                    .HasColumnName("day_found")
                    .HasColumnType("ntext");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .HasColumnType("ntext");

                entity.Property(e => e.DorsalPitting)
                    .HasColumnName("dorsal_pitting")
                    .HasColumnType("ntext");

                entity.Property(e => e.EpiphysealUnion)
                    .HasColumnName("epiphyseal_union")
                    .HasColumnType("ntext");

                entity.Property(e => e.EstimateAge)
                    .HasColumnName("estimate_age")
                    .HasColumnType("ntext");

                entity.Property(e => e.EstimateLivingStature)
                    .HasColumnName("estimate_living_stature")
                    .HasColumnType("ntext");

                entity.Property(e => e.FemurHead)
                    .HasColumnName("femur_head")
                    .HasColumnType("ntext");

                entity.Property(e => e.FemurLength)
                    .HasColumnName("femur_length")
                    .HasColumnType("ntext");

                entity.Property(e => e.ForamanMagnum)
                    .HasColumnName("foraman_magnum")
                    .HasColumnType("ntext");

                entity.Property(e => e.Gamous)
                    .HasColumnName("gamous")
                    .HasColumnType("ntext");

                entity.Property(e => e.GeFunctionTotal)
                    .HasColumnName("GE_function_total")
                    .HasColumnType("ntext");

                entity.Property(e => e.GenderBodyCol)
                    .HasColumnName("gender_body_col")
                    .HasColumnType("ntext");

                entity.Property(e => e.GenderGe)
                    .HasColumnName("gender_GE")
                    .HasColumnType("ntext");

                entity.Property(e => e.Gonian)
                    .HasColumnName("gonian")
                    .HasColumnType("ntext");

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasColumnType("ntext");

                entity.Property(e => e.HairTaken)
                    .HasColumnName("hair_taken")
                    .HasColumnType("ntext");

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasColumnType("ntext");

                entity.Property(e => e.HighPairEw)
                    .HasColumnName("high_pair_EW")
                    .HasColumnType("ntext");

                entity.Property(e => e.HighPairNs)
                    .HasColumnName("high_pair_NS")
                    .HasColumnType("ntext");

                entity.Property(e => e.HumerusHead)
                    .HasColumnName("humerus_head")
                    .HasColumnType("ntext");

                entity.Property(e => e.HumerusLength)
                    .HasColumnName("humerus_length")
                    .HasColumnType("ntext");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasColumnName("interorbital_breadth")
                    .HasColumnType("ntext");

                entity.Property(e => e.LengthOfRemainsCentimeters)
                    .HasColumnName("length_of_remains_centimeters")
                    .HasColumnType("ntext");

                entity.Property(e => e.LengthOfRemainsMeters)
                    .HasColumnName("length_of_remains_meters")
                    .HasColumnType("ntext");

                entity.Property(e => e.LowPairEw)
                    .HasColumnName("low_pair_EW")
                    .HasColumnType("ntext");

                entity.Property(e => e.LowPairNs)
                    .HasColumnName("low_pair_NS")
                    .HasColumnType("ntext");

                entity.Property(e => e.MaximumCranialBreadth)
                    .HasColumnName("maximum_cranial_breadth")
                    .HasColumnType("ntext");

                entity.Property(e => e.MaximumCranialLength)
                    .HasColumnName("maximum_cranial_length")
                    .HasColumnType("ntext");

                entity.Property(e => e.MaximumNasalBreadth)
                    .HasColumnName("maximum_nasal_breadth")
                    .HasColumnType("ntext");

                entity.Property(e => e.MedialIpRamus)
                    .HasColumnName("medial_IP_ramus")
                    .HasColumnType("ntext");

                entity.Property(e => e.MonthFound)
                    .HasColumnName("month_found")
                    .HasColumnType("ntext");

                entity.Property(e => e.NasionProsthion)
                    .HasColumnName("nasion_prosthion")
                    .HasColumnType("ntext");

                entity.Property(e => e.NuchalCrest)
                    .HasColumnName("nuchal_crest")
                    .HasColumnType("ntext");

                entity.Property(e => e.OrbitEdge)
                    .HasColumnName("orbit_edge")
                    .HasColumnType("ntext");

                entity.Property(e => e.Osteophytosis)
                    .HasColumnName("osteophytosis")
                    .HasColumnType("ntext");

                entity.Property(e => e.ParietalBossing)
                    .HasColumnName("parietal_bossing")
                    .HasColumnType("ntext");

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .HasColumnType("ntext");

                entity.Property(e => e.PreaurSulcus)
                    .HasColumnName("preaur_sulcus")
                    .HasColumnType("ntext");

                entity.Property(e => e.PreservationIndex)
                    .HasColumnName("preservation_index")
                    .HasColumnType("ntext");

                entity.Property(e => e.PubicBone)
                    .HasColumnName("pubic_bone")
                    .HasColumnType("ntext");

                entity.Property(e => e.PubicSymphysis)
                    .HasColumnName("pubic_symphysis")
                    .HasColumnType("ntext");

                entity.Property(e => e.Robust)
                    .HasColumnName("robust")
                    .HasColumnType("ntext");

                entity.Property(e => e.SampleNumber)
                    .HasColumnName("sample_number")
                    .HasColumnType("ntext");

                entity.Property(e => e.SampleTaken)
                    .HasColumnName("sample_taken")
                    .HasColumnType("ntext");

                entity.Property(e => e.SciaticNotch)
                    .HasColumnName("sciatic_notch")
                    .HasColumnType("ntext");

                entity.Property(e => e.SexMethod)
                    .HasColumnName("sex_method")
                    .HasColumnType("ntext");

                entity.Property(e => e.SoftTissueTaken)
                    .HasColumnName("soft_tissue_taken")
                    .HasColumnType("ntext");

                entity.Property(e => e.SouthToFeet)
                    .HasColumnName("south_to_feet")
                    .HasColumnType("ntext");

                entity.Property(e => e.SouthToHead)
                    .HasColumnName("south_to_head")
                    .HasColumnType("ntext");

                entity.Property(e => e.SubpubicAngle)
                    .HasColumnName("subpubic_angle")
                    .HasColumnType("ntext");

                entity.Property(e => e.SupraorbitalRidges)
                    .HasColumnName("supraorbital_ridges")
                    .HasColumnType("ntext");

                entity.Property(e => e.TextileTaken)
                    .HasColumnName("textile_taken")
                    .HasColumnType("ntext");

                entity.Property(e => e.TibiaLength)
                    .HasColumnName("tibia_length")
                    .HasColumnType("ntext");

                entity.Property(e => e.ToothAttrition)
                    .HasColumnName("tooth_attrition")
                    .HasColumnType("ntext");

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasColumnType("ntext");

                entity.Property(e => e.ToothTaken)
                    .HasColumnName("tooth_taken")
                    .HasColumnType("ntext");

                entity.Property(e => e.VentralArc)
                    .HasColumnName("ventral_arc")
                    .HasColumnType("ntext");

                entity.Property(e => e.WestToFeet)
                    .HasColumnName("west_to_feet")
                    .HasColumnType("ntext");

                entity.Property(e => e.WestToHead)
                    .HasColumnName("west_to_head")
                    .HasColumnType("ntext");

                entity.Property(e => e.YearFound)
                    .HasColumnName("year_found")
                    .HasColumnType("ntext");

                entity.Property(e => e.ZygomaticCrest)
                    .HasColumnName("zygomatic_crest")
                    .HasColumnType("ntext");
                // Jonah added this and it works!
                entity.Property(e => e.BurialIdInt)
                    .HasColumnName("burial_id_int");
                entity.Property(e => e.HasPhoto)
                    .HasColumnName("has_photo");
            });

            modelBuilder.Entity<C14>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialId)
                    .HasColumnName("Burial_ID")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BurialLocationEw)
                    .HasColumnName("burial_location_EW")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialLocationNs)
                    .HasColumnName("burial_location_NS")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialNumber)
                    .HasColumnName("burial_number")
                    .HasColumnType("ntext");

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasColumnType("ntext");

                entity.Property(e => e.C14Sample2017)
                    .HasColumnName("c14_sample_2017")
                    .HasColumnType("ntext");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .HasColumnName("calibrated_95_calendar_date_avg")
                    .HasColumnType("ntext");

                entity.Property(e => e.Calibrated95CalendarDateMax)
                    .HasColumnName("calibrated_95_calendar_date_max")
                    .HasColumnType("ntext");

                entity.Property(e => e.Calibrated95CalendarDateMin)
                    .HasColumnName("calibrated_95_calendar_date_min")
                    .HasColumnType("ntext");

                entity.Property(e => e.Calibrated95CalendarDateSpan)
                    .HasColumnName("calibrated_95_calendar_date_span")
                    .HasColumnType("ntext");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("ntext");

                entity.Property(e => e.Column17)
                    .HasColumnName("column17")
                    .HasColumnType("ntext");

                entity.Property(e => e.Conventional14cAgeBp)
                    .HasColumnName("conventional_14C_age_bp")
                    .HasColumnType("ntext");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("ntext");

                entity.Property(e => e.Foci)
                    .HasColumnName("foci")
                    .HasColumnType("ntext");

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasColumnType("ntext");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("ntext");

                entity.Property(e => e.LowPairEw)
                    .HasColumnName("low_pair_EW")
                    .HasColumnType("ntext");

                entity.Property(e => e.LowPairNs)
                    .HasColumnName("low_pair_NS")
                    .HasColumnType("ntext");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("ntext");

                entity.Property(e => e.QuestionS)
                    .HasColumnName("question_s")
                    .HasColumnType("ntext");

                entity.Property(e => e.Rack)
                    .HasColumnName("rack")
                    .HasColumnType("ntext");

                entity.Property(e => e.SizeMl)
                    .HasColumnName("size_ml")
                    .HasColumnType("ntext");

                entity.Property(e => e.TubeNum)
                    .HasColumnName("tube_num")
                    .HasColumnType("ntext");

                entity.Property(e => e._14cCalendarDate)
                    .HasColumnName("_14c_calendar_date")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Cranial>(entity =>
            {
                entity.HasKey(e => e.SampleNumber);

                entity.Property(e => e.SampleNumber)
                    .HasColumnName("sample_number")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BasionBregmaHeight)
                    .HasColumnName("basion_bregma_height")
                    .HasColumnType("float");

                entity.Property(e => e.BasionNasion)
                    .HasColumnName("basion_nasion")
                    .HasColumnType("float");

                entity.Property(e => e.BasionProsthionLength)
                    .HasColumnName("basion_prosthion_length")
                    .HasColumnType("float");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasColumnName("bizygomatic_diameter")
                    .HasColumnType("float");

                entity.Property(e => e.BodyGender)
                    .HasColumnName("body_gender")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BurialArtifactDescription)
                    .HasColumnName("burial_artifact_description")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BurialDepth)
                    .IsRequired()
                    .HasColumnName("burial_depth")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BurialId)
                    .IsRequired()
                    .HasColumnName("Burial_Id")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BurialLocationNs)
                    .IsRequired()
                    .HasColumnName("burial_location_NS")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BurialNumer)
                    .IsRequired()
                    .HasColumnName("burial_numer")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BurialPositioningEastWestDirection)
                    .IsRequired()
                    .HasColumnName("burial_positioning_east_west_direction")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BurialSubPlotDirection)
                    .HasColumnName("burial_sub_plot_direction")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.BuriedWithArtifacts)
                    .IsRequired()
                    .HasColumnName("buried_with_artifacts")
                    .HasColumnType("bit");

                entity.Property(e => e.GilesGender)
                    .HasColumnName("giles_gender")
                    .HasColumnType("nvarchar(1)");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasColumnName("interorbital_breadth")
                    .HasColumnType("float");

                entity.Property(e => e.LowHighPairEw)
                    .IsRequired()
                    .HasColumnName("low_high_pair_EW")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.LowHighPairNs)
                    .IsRequired()
                    .HasColumnName("low_high_pair_NS")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.MaximumCranialBreadth)
                    .HasColumnName("maximum_cranial_breadth")
                    .HasColumnType("float");

                entity.Property(e => e.MaximumCranialLength)
                    .HasColumnName("maximum_cranial_length")
                    .HasColumnType("float");

                entity.Property(e => e.MaximumNasalBreadth)
                    .HasColumnName("maximum_nasal_breadth")
                    .HasColumnType("float");

                entity.Property(e => e.NasionProsthion)
                    .HasColumnName("nasion_prosthion")
                    .HasColumnType("float");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
