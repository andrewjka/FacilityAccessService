﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations.Stages
{
    [DbContext(typeof(AppDatabaseContext))]
    partial class AppDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Persistence.AccessScope.Models.UserCategory", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserCategories");
                });

            modelBuilder.Entity("Persistence.AccessScope.Models.UserFacility", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("FacilityId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "FacilityId");

                    b.HasIndex("FacilityId");

                    b.ToTable("UserFacilities");
                });

            modelBuilder.Entity("Persistence.AuthScope.Models.RefreshToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Token")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "Token");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Persistence.FacilityScope.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Persistence.FacilityScope.Models.CategoryFacility", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FacilityId")
                        .HasColumnType("char(36)");

                    b.HasKey("CategoryId", "FacilityId");

                    b.HasIndex("FacilityId");

                    b.ToTable("CategoryFacilities");
                });

            modelBuilder.Entity("Persistence.FacilityScope.Models.Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("Persistence.TerminalScope.Models.Terminal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("ExpiredTokenOn")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("Persistence.UserScope.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Persistence.AccessScope.Models.UserCategory", b =>
                {
                    b.HasOne("Persistence.FacilityScope.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.UserScope.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.AccessScope.ValueObjects.AccessPeriod", "AccessPeriod", b1 =>
                        {
                            b1.Property<string>("UserCategoryUserId")
                                .HasColumnType("varchar(255)");

                            b1.Property<Guid>("UserCategoryCategoryId")
                                .HasColumnType("char(36)");

                            b1.Property<DateOnly>("EndDate")
                                .HasColumnType("date");

                            b1.Property<DateOnly>("StartDate")
                                .HasColumnType("date");

                            b1.HasKey("UserCategoryUserId", "UserCategoryCategoryId");

                            b1.ToTable("UserCategories");

                            b1.WithOwner()
                                .HasForeignKey("UserCategoryUserId", "UserCategoryCategoryId");
                        });

                    b.Navigation("AccessPeriod");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Persistence.AccessScope.Models.UserFacility", b =>
                {
                    b.HasOne("Persistence.FacilityScope.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.UserScope.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.AccessScope.ValueObjects.AccessPeriod", "AccessPeriod", b1 =>
                        {
                            b1.Property<string>("UserFacilityUserId")
                                .HasColumnType("varchar(255)");

                            b1.Property<Guid>("UserFacilityFacilityId")
                                .HasColumnType("char(36)");

                            b1.Property<DateOnly>("EndDate")
                                .HasColumnType("date");

                            b1.Property<DateOnly>("StartDate")
                                .HasColumnType("date");

                            b1.HasKey("UserFacilityUserId", "UserFacilityFacilityId");

                            b1.ToTable("UserFacilities");

                            b1.WithOwner()
                                .HasForeignKey("UserFacilityUserId", "UserFacilityFacilityId");
                        });

                    b.Navigation("AccessPeriod");

                    b.Navigation("Facility");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Persistence.AuthScope.Models.RefreshToken", b =>
                {
                    b.HasOne("Persistence.UserScope.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Persistence.FacilityScope.Models.CategoryFacility", b =>
                {
                    b.HasOne("Persistence.FacilityScope.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.FacilityScope.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Facility");
                });
#pragma warning restore 612, 618
        }
    }
}
