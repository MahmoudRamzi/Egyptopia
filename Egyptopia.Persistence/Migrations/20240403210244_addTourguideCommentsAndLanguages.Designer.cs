﻿// <auto-generated />
using System;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240403210244_addTourguideCommentsAndLanguages")]
    partial class addTourguideCommentsAndLanguages
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Egyptopia.Domain.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<Guid?>("TourGuideId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("TourGuideId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Governorate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Governorates");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.HotelComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelComment");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ImageEntity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GovernorateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TourGuideId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GovernorateId");

                    b.HasIndex("TourGuideId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberFrom")
                        .HasColumnType("int");

                    b.Property<int>("NumberTo")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.TourGuide", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AboutInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TourGuids");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.TourGuideComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("PublishedDate")
                        .HasColumnType("date");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("TourGuideId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("TourGuideId");

                    b.ToTable("TourGuideComments");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.TourGuideLanguage", b =>
                {
                    b.Property<Guid>("TourGuideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TourGuideId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("TourGuideLanguages");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.TourGuideService", b =>
                {
                    b.Property<Guid>("TourGuideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TourGuideId", "PlaceId");

                    b.HasIndex("PlaceId");

                    b.ToTable("TourGuideServices");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Booking", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("Egyptopia.Domain.Entities.TourGuide", "TourGuide")
                        .WithMany()
                        .HasForeignKey("TourGuideId");

                    b.Navigation("Room");

                    b.Navigation("TourGuide");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.HotelComment", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("HotelComments")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Egyptopia.Domain.Entities.Hotel", "Hotel")
                        .WithMany("HotelComments")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Place", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.Governorate", "Governorate")
                        .WithMany("Places")
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Egyptopia.Domain.Entities.TourGuide", null)
                        .WithMany("Places")
                        .HasForeignKey("TourGuideId");

                    b.Navigation("Governorate");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Room", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.TourGuideComment", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("TourGuideComments")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Egyptopia.Domain.Entities.TourGuide", "TourGuide")
                        .WithMany("TourGuideComments")
                        .HasForeignKey("TourGuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("TourGuide");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.TourGuideLanguage", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.Language", "Language")
                        .WithMany("TourGuideLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Egyptopia.Domain.Entities.TourGuide", "TourGuide")
                        .WithMany("TourGuideLanguages")
                        .HasForeignKey("TourGuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("TourGuide");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.TourGuideService", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Egyptopia.Domain.Entities.TourGuide", "TourGuide")
                        .WithMany()
                        .HasForeignKey("TourGuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("TourGuide");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Egyptopia.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Egyptopia.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("HotelComments");

                    b.Navigation("TourGuideComments");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Governorate", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("HotelComments");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.Language", b =>
                {
                    b.Navigation("TourGuideLanguages");
                });

            modelBuilder.Entity("Egyptopia.Domain.Entities.TourGuide", b =>
                {
                    b.Navigation("Places");

                    b.Navigation("TourGuideComments");

                    b.Navigation("TourGuideLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
