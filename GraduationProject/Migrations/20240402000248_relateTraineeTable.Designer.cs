﻿// <auto-generated />
using System;
using GraduationProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraduationProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240402000248_relateTraineeTable")]
    partial class relateTraineeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraduationProject.Models.DailyActivity", b =>
                {
                    b.Property<int>("traineeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("traineeId", "date");

                    b.ToTable("DailyActivity");
                });

            modelBuilder.Entity("GraduationProject.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<double>("Carbs")
                        .HasColumnType("float");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fat")
                        .HasColumnType("float");

                    b.Property<double>("Fiber")
                        .HasColumnType("float");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Grams")
                        .HasColumnType("float");

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.Property<double>("Sat_Fat")
                        .HasColumnType("float");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("GraduationProject.Models.FoodEaten", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("DailyActivitydate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DailyActivitytraineeId")
                        .HasColumnType("int");

                    b.Property<int>("foodId")
                        .HasColumnType("int");

                    b.Property<double>("quantity")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("DailyActivitytraineeId", "DailyActivitydate");

                    b.ToTable("FoodEatens");
                });

            modelBuilder.Entity("GraduationProject.Models.FoodReport", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<DateTime>("DateOfOccurrence")
                        .HasColumnType("datetime2");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int>("foodId")
                        .HasColumnType("int");

                    b.Property<double>("quantity")
                        .HasColumnType("float");

                    b.HasKey("ReportId");

                    b.ToTable("FoodReports");
                });

            modelBuilder.Entity("GraduationProject.Models.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SportId"));

                    b.Property<double>("CaloreisPerKg")
                        .HasColumnType("float");

                    b.Property<string>("SportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportId");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("GraduationProject.Models.SportDone", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("DailyActivitydate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DailyActivitytraineeId")
                        .HasColumnType("int");

                    b.Property<double>("duration")
                        .HasColumnType("float");

                    b.Property<int>("sportId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("DailyActivitytraineeId", "DailyActivitydate");

                    b.ToTable("SportDones");
                });

            modelBuilder.Entity("GraduationProject.Models.SportReport", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<DateTime>("DateOfOccurrence")
                        .HasColumnType("datetime2");

                    b.Property<double>("DurationTime")
                        .HasColumnType("float");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int>("sportId")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.ToTable("SportReports");
                });

            modelBuilder.Entity("GraduationProject.Models.Trainee", b =>
                {
                    b.Property<int>("TraineeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TraineeId"));

                    b.Property<string>("AvailabaleDays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitnessLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasTools")
                        .HasColumnType("bit");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequiredCalories")
                        .HasColumnType("int");

                    b.Property<string>("TraineeFoods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraineeSports")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("TraineeId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("GraduationProject.Models.FoodEaten", b =>
                {
                    b.HasOne("GraduationProject.Models.DailyActivity", null)
                        .WithMany("dailyFoodEaten")
                        .HasForeignKey("DailyActivitytraineeId", "DailyActivitydate");
                });

            modelBuilder.Entity("GraduationProject.Models.SportDone", b =>
                {
                    b.HasOne("GraduationProject.Models.DailyActivity", null)
                        .WithMany("dailySportDone")
                        .HasForeignKey("DailyActivitytraineeId", "DailyActivitydate");
                });

            modelBuilder.Entity("GraduationProject.Models.DailyActivity", b =>
                {
                    b.Navigation("dailyFoodEaten");

                    b.Navigation("dailySportDone");
                });
#pragma warning restore 612, 618
        }
    }
}
