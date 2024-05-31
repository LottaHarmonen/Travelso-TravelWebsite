﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travelso_Website.DataAccess;

#nullable disable

namespace Travelso_Website.DataAccess.Migrations
{
    [DbContext(typeof(TravelsoSQLDataContext))]
    [Migration("20240528134347_init2")]
    partial class init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CountryTravelsoUser", b =>
                {
                    b.Property<int>("MyVisitedCountriesCountryId")
                        .HasColumnType("int");

                    b.Property<string>("TravelsoUsersUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MyVisitedCountriesCountryId", "TravelsoUsersUserId");

                    b.HasIndex("TravelsoUsersUserId");

                    b.ToTable("CountryTravelsoUser");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogPostId"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("HtmlContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TravelsoUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TravelsoUserUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BlogPostId");

                    b.HasIndex("TravelsoUserUserId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("TravelsoUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("publicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CommentId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DestinationId"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinationId");

                    b.HasIndex("CountryId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.TravelsoUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("TravelsoUsers");
                });

            modelBuilder.Entity("CountryTravelsoUser", b =>
                {
                    b.HasOne("Travelso_Website_Shared.Entities.Country", null)
                        .WithMany()
                        .HasForeignKey("MyVisitedCountriesCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travelso_Website_Shared.Entities.TravelsoUser", null)
                        .WithMany()
                        .HasForeignKey("TravelsoUsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.BlogPost", b =>
                {
                    b.HasOne("Travelso_Website_Shared.Entities.TravelsoUser", null)
                        .WithMany("BlogPosts")
                        .HasForeignKey("TravelsoUserUserId");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.Comment", b =>
                {
                    b.HasOne("Travelso_Website_Shared.Entities.BlogPost", null)
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.Destination", b =>
                {
                    b.HasOne("Travelso_Website_Shared.Entities.Country", "Country")
                        .WithMany("Destinations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.BlogPost", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.Country", b =>
                {
                    b.Navigation("Destinations");
                });

            modelBuilder.Entity("Travelso_Website_Shared.Entities.TravelsoUser", b =>
                {
                    b.Navigation("BlogPosts");
                });
#pragma warning restore 612, 618
        }
    }
}