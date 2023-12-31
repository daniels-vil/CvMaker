﻿// <auto-generated />
using System;
using CvMaker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CvMaker.Data.Migrations
{
    [DbContext(typeof(CvDbContext))]
    [Migration("20231103174353_AddedSection")]
    partial class AddedSection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CvMaker.Core.Models.CurriculumVitae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OtherName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("curriculumVitae");
                });

            modelBuilder.Entity("CvMaker.Core.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<string>("EducationalLevel")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Faculty")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameOfSchool")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("StudyEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudyProgram")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("StudyStartDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("education");
                });

            modelBuilder.Entity("CvMaker.Core.Models.Employment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DurationOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobPosition")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("NameOfCompany")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WorkLoad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("employment");
                });

            modelBuilder.Entity("CvMaker.Core.Models.LanguageKnowledge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("LanguageLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("languageKnowledge");
                });

            modelBuilder.Entity("CvMaker.Core.Models.Skills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CurriculumVitaeId")
                        .HasColumnType("int");

                    b.Property<string>("SkillDescription")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("skills");
                });

            modelBuilder.Entity("CvMaker.Core.Models.Education", b =>
                {
                    b.HasOne("CvMaker.Core.Models.CurriculumVitae", "CurriculumVitae")
                        .WithMany()
                        .HasForeignKey("CurriculumVitaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("CvMaker.Core.Models.Employment", b =>
                {
                    b.HasOne("CvMaker.Core.Models.CurriculumVitae", "CurriculumVitae")
                        .WithMany()
                        .HasForeignKey("CurriculumVitaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("CvMaker.Core.Models.LanguageKnowledge", b =>
                {
                    b.HasOne("CvMaker.Core.Models.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Languages")
                        .HasForeignKey("CurriculumVitaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("CvMaker.Core.Models.Skills", b =>
                {
                    b.HasOne("CvMaker.Core.Models.CurriculumVitae", "CurriculumVitae")
                        .WithMany()
                        .HasForeignKey("CurriculumVitaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("CvMaker.Core.Models.CurriculumVitae", b =>
                {
                    b.Navigation("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
