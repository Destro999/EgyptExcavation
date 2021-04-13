using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class FileUploadsContext : DbContext
    {
        public FileUploadsContext()
        {
        }

        public FileUploadsContext(DbContextOptions<FileUploadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Files> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source = FileUploads.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                //entity.Property(e => e.DocumentId).ValueGeneratedNever();

                entity.Property(e => e.BurialId).HasColumnType("nvarchar(50)");

                entity.Property(e => e.DataFiles).HasColumnType("varbinary(max)");

                entity.Property(e => e.FileType).HasColumnType("nvarchar(50)");

                entity.Property(e => e.Name).HasColumnType("nvarchar(50)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
