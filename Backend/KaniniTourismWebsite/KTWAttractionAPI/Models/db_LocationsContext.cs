using System;
using System.Collections.Generic;
using KTWAttractionAPI.Models.StaticTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KTWAttractionAPI.Models
{
    public partial class db_LocationsContext : DbContext
    {
        public db_LocationsContext()
        {
        }

        public db_LocationsContext(DbContextOptions<db_LocationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country>? Countries { get; set; } = null!;
        public virtual DbSet<State>? States { get; set; } = null!;
        public virtual DbSet<Attraction>? Attractions { get; set; } 
        public  DbSet<AttractionLikes>? AttractionLikes { get; set; } 
        public  DbSet<Speciality>? Speciality { get; set; }


//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=MATHANRAJ\\SQLEXPRESS;Integrated Security=true;Initial Catalog=db_Locations");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speciality>().HasData(
                    new Speciality
                    {
                        Id= 1,
                        SpecialityName = "Historical Castles and Palaces"
                    },
                    new Speciality
                    {
                        Id=2,
                        SpecialityName = "Cultural and Historical Sites"
                    },
                    new Speciality
                    {
                        Id=3,
                        SpecialityName = "Adventure Sports and Extreme Activities"
                    },
                    new Speciality
                    {
                        Id=4,
                        SpecialityName = "Wildlife and Safari Tours:"
                    },
                    new Speciality
                    {
                        Id=5,
                        SpecialityName = "Wellness and Spa Retreats"
                    },
                    new Speciality
                    {
                        Id=6,
                        SpecialityName = "Culinary and Food Tours"
                    },
                    new Speciality
                    {
                        Id=7,
                        SpecialityName = "Adventure Cruises and Sailing"
                    },
                    new Speciality
                    {
                        Id=8,
                        SpecialityName = "Winter Sports and Ski Resorts"
                    },
                    new Speciality
                    {
                        Id=9,
                        SpecialityName = "Desert Adventures"
                    },
                     new Speciality
                     {
                            Id=10,
                         SpecialityName = "Eco-Tourism and Sustainable Travel"
                     }
                ); ;

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(50)
                    .HasColumnName("country_code");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .HasColumnName("country_name");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(50)
                    .HasColumnName("state_code");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.StateName).HasColumnName("state_name");

                entity.Property(e => e.WikiDataId)
                    .HasColumnType("money")
                    .HasColumnName("wikiDataId");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cities_States");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Capital)
                    .HasMaxLength(50)
                    .HasColumnName("capital");

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .HasColumnName("currency");

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(50)
                    .HasColumnName("currency_name");

                entity.Property(e => e.CurrencySymbol)
                    .HasMaxLength(50)
                    .HasColumnName("currency_symbol");

                entity.Property(e => e.Emoji)
                    .HasMaxLength(50)
                    .HasColumnName("emoji");

                entity.Property(e => e.EmojiU)
                    .HasMaxLength(50)
                    .HasColumnName("emojiU");

                entity.Property(e => e.Iso2)
                    .HasMaxLength(50)
                    .HasColumnName("iso2");

                entity.Property(e => e.Iso3)
                    .HasMaxLength(50)
                    .HasColumnName("iso3");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Native)
                    .HasMaxLength(100)
                    .HasColumnName("native");

                entity.Property(e => e.NumericCode).HasColumnName("numeric_code");

                entity.Property(e => e.PhoneCode)
                    .HasMaxLength(50)
                    .HasColumnName("phone_code");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .HasColumnName("region");

                entity.Property(e => e.Subregion)
                    .HasMaxLength(50)
                    .HasColumnName("subregion");

                entity.Property(e => e.Timezones).HasColumnName("timezones");

                entity.Property(e => e.Tld)
                    .HasMaxLength(50)
                    .HasColumnName("tld");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(50)
                    .HasColumnName("country_code");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .HasColumnName("country_name");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(50)
                    .HasColumnName("state_code");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_States_Countries");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
