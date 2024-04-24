﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNGO.Infrastructure.Db;

#nullable disable

namespace SocialNGO.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240418185133_LoginRegisterMigration")]
    partial class LoginRegisterMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("BlockName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.BloodGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("BloodGroups");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.PasswordHistroy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Hash")
                        .HasColumnType("longtext");

                    b.Property<string>("Salt")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PasswordHistroys");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.PostingBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("PostingBlocks");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.PostingCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("PostingCities");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.PostingState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("PostingStates");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.UserRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlternateMobileNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeseaseDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmpCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsAlreadyRegister")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDesease")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nominee1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nominee1MobileNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nominee1Relation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nominee2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nominee2MobileNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nominee2Relation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddressLine2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updatated_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("bloodGroupId")
                        .HasColumnType("int");

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.Property<int>("countryId")
                        .HasColumnType("int");

                    b.Property<int>("degsignationId")
                        .HasColumnType("int");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<int>("postingBlockId")
                        .HasColumnType("int");

                    b.Property<int>("postingCityId")
                        .HasColumnType("int");

                    b.Property<int>("postingStateId")
                        .HasColumnType("int");

                    b.Property<int>("regionId")
                        .HasColumnType("int");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<int>("stateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("bloodGroupId");

                    b.HasIndex("cityId");

                    b.HasIndex("countryId");

                    b.HasIndex("degsignationId");

                    b.HasIndex("departmentId");

                    b.HasIndex("postingBlockId");

                    b.HasIndex("postingCityId");

                    b.HasIndex("postingStateId");

                    b.HasIndex("regionId");

                    b.HasIndex("roleId");

                    b.HasIndex("stateId");

                    b.ToTable("UserRegistration");
                });

            modelBuilder.Entity("SocialNGO.Infrastructure.Db.Entities.UserRegistration", b =>
                {
                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.BloodGroup", "bloodGroup")
                        .WithMany()
                        .HasForeignKey("bloodGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.City", "city")
                        .WithMany()
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.Designation", "degsignation")
                        .WithMany()
                        .HasForeignKey("degsignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.Department", "department")
                        .WithMany()
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.PostingBlock", "postingBlock")
                        .WithMany()
                        .HasForeignKey("postingBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.PostingCity", "postingCity")
                        .WithMany()
                        .HasForeignKey("postingCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.PostingState", "postingState")
                        .WithMany()
                        .HasForeignKey("postingStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.Roles", "role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNGO.Infrastructure.Db.Entities.State", "state")
                        .WithMany()
                        .HasForeignKey("stateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bloodGroup");

                    b.Navigation("city");

                    b.Navigation("country");

                    b.Navigation("degsignation");

                    b.Navigation("department");

                    b.Navigation("postingBlock");

                    b.Navigation("postingCity");

                    b.Navigation("postingState");

                    b.Navigation("region");

                    b.Navigation("role");

                    b.Navigation("state");
                });
#pragma warning restore 612, 618
        }
    }
}
