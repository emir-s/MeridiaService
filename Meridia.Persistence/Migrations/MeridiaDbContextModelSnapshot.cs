// <auto-generated />
using System;
using Meridia.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meridia.Persistence.Migrations
{
    [DbContext(typeof(MeridiaDbContext))]
    partial class MeridiaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.Address", b =>
                {
                    b.Property<Guid>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DistrictID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AddressID");

                    b.HasIndex("DistrictID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.City", b =>
                {
                    b.Property<Guid>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CountryID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CityID");

                    b.HasIndex("CountryID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.Country", b =>
                {
                    b.Property<Guid>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.District", b =>
                {
                    b.Property<Guid>("DistrictID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DistrictCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DistrictID");

                    b.HasIndex("CityID");

                    b.ToTable("District");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Users.UserLocations", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("IsPrimary")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserLocationsID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserID", "AddressID");

                    b.HasIndex("AddressID");

                    b.ToTable("UserLocations");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Users.Users", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.Address", b =>
                {
                    b.HasOne("Meridia.Domain.Entities.Locations.District", "District")
                        .WithMany("Addresses")
                        .HasForeignKey("DistrictID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.City", b =>
                {
                    b.HasOne("Meridia.Domain.Entities.Locations.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.District", b =>
                {
                    b.HasOne("Meridia.Domain.Entities.Locations.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Users.UserLocations", b =>
                {
                    b.HasOne("Meridia.Domain.Entities.Locations.Address", "Address")
                        .WithMany("UserLocations")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meridia.Domain.Entities.Users.Users", "User")
                        .WithMany("UserLocations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.Address", b =>
                {
                    b.Navigation("UserLocations");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Locations.District", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Meridia.Domain.Entities.Users.Users", b =>
                {
                    b.Navigation("UserLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
