﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectWeb.Lib;

namespace ProjectWeb.Lib.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectWeb.Lib.Models.Course", b =>
                {
                    b.Property<int>("IdCourse")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCourse");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("ProjectWeb.Lib.Models.Departament", b =>
                {
                    b.Property<string>("DepartamentName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DepartamentName");

                    b.ToTable("Departament");
                });

            modelBuilder.Entity("ProjectWeb.Lib.Models.Subject", b =>
                {
                    b.Property<int>("IdSubject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseIdCourse")
                        .HasColumnType("int");

                    b.Property<double>("Grades")
                        .HasColumnType("float");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int");

                    b.Property<int>("IdTeacher")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherIdTeacher")
                        .HasColumnType("int");

                    b.HasKey("IdSubject");

                    b.HasIndex("CourseIdCourse");

                    b.HasIndex("TeacherIdTeacher");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("ProjectWeb.Lib.Models.Teacher", b =>
                {
                    b.Property<int>("IdTeacher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartamentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartamentName1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTeacher");

                    b.HasIndex("DepartamentName1");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("ProjectWeb.Lib.Models.Subject", b =>
                {
                    b.HasOne("ProjectWeb.Lib.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseIdCourse");

                    b.HasOne("ProjectWeb.Lib.Models.Teacher", "Teacher")
                        .WithMany("Subject")
                        .HasForeignKey("TeacherIdTeacher");

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ProjectWeb.Lib.Models.Teacher", b =>
                {
                    b.HasOne("ProjectWeb.Lib.Models.Departament", "Departament")
                        .WithMany()
                        .HasForeignKey("DepartamentName1");

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("ProjectWeb.Lib.Models.Teacher", b =>
                {
                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
