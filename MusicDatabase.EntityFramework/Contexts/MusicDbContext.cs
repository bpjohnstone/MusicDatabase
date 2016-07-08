using System.Configuration;
using System.Data.Entity;
using MusicDatabase.Model;

namespace MusicDatabase.EntityFramework
{
    public class MusicDbContext : DbContext
    {
        #region Constructors
        public MusicDbContext()
            : base(ConfigurationManager.ConnectionStrings["mssql.musicdb"].ConnectionString)
        {
        }
        #endregion

        #region Configuration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Convention added in, so automatically generated Foreign Keys are in the form <Entity>ID
            modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());

            modelBuilder.Entity<Person>()
                .HasMany(c => c.GiftsGiven)
                .WithMany()
                .Map(g =>
                {
                    g.MapLeftKey("PersonID");
                    g.MapRightKey("CopyID");
                    g.ToTable("PersonGiftsGiven");
                });

            modelBuilder.Entity<Person>()
                .HasMany(p => p.EventsAttended)
                .WithMany()
                .Map(e =>
                {
                    e.MapLeftKey("PersonID");
                    e.MapRightKey("MusicalEventID");
                    e.ToTable("PersonEventsAttended");
                });

            modelBuilder.Entity<MusicalEntity>()
                .HasMany(e => e.Performances)
                .WithMany()
                .Map(e => 
                {
                    e.MapLeftKey("MusicalEntityID");
                    e.MapRightKey("PerformanceID");
                    e.ToTable("MusicalEntityPerformances");
                });

            modelBuilder.Entity<Artist>();
            modelBuilder.Entity<MusicalGroup>();

            modelBuilder.Entity<DiscographyEntry>();

            modelBuilder.Entity<Release>()
                .Map(r =>
                {
                    r.MapInheritedProperties();
                    r.ToTable("Releases");
                });

            modelBuilder.Entity<Copy>()
                .Map(c =>
                {
                    c.MapInheritedProperties();
                    c.ToTable("Copies");
                });

            modelBuilder.Entity<Element>();
            modelBuilder.Entity<Format>();

            modelBuilder.Entity<AcquisitionDetails>();
            modelBuilder.Entity<GiftDetails>()
                .HasMany(g => g.From)
                .WithMany()
                .Map(p =>
                {
                    p.MapLeftKey("GiftDetailsID");
                    p.MapRightKey("PersonID");
                    p.ToTable("GiftFrom");
                });

            modelBuilder.Entity<Location>();
            modelBuilder.Entity<AlternateLocationName>()
                .ToTable("LocationAlternateName"); // So it gets grouped with the other Location tables

            modelBuilder.Entity<LocationGroup>();

            modelBuilder.Entity<Website>();

            modelBuilder.Entity<MusicalEvent>();
            modelBuilder.Entity<EventGroup>();
            modelBuilder.Entity<Concert>();
            modelBuilder.Entity<Festival>();

            modelBuilder.Entity<Performance>();
            modelBuilder.Entity<Performer>();
        }
        #endregion
    }
}