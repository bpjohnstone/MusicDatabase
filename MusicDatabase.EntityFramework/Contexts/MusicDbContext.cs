using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
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

            modelBuilder.Entity<Person>();

            modelBuilder.Entity<MusicalEntity>();
            modelBuilder.Entity<Artist>();
            modelBuilder.Entity<MusicalGroup>();

            modelBuilder.Entity<DiscographyEntry>();
            modelBuilder.Entity<Release>();
            modelBuilder.Entity<Copy>();
            modelBuilder.Entity<Element>();
            modelBuilder.Entity<Format>();

            modelBuilder.Entity<AcquisitionDetails>();

            modelBuilder.Entity<Location>();
            modelBuilder.Entity<Website>();

            modelBuilder.Entity<MusicalEvent>();
            modelBuilder.Entity<Concert>();
            modelBuilder.Entity<Festival>();
            modelBuilder.Entity<Performance>();
            modelBuilder.Entity<Attendance>();
        }
        #endregion
    }
}