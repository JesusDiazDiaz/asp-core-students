﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MvcRelaciones.Data;
using MvcRelaciones.Models;
using System;

namespace MvcRelaciones.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcRelaciones.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Credits");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CourseID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("MvcRelaciones.Models.Inscripcion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int>("EstudentID");

                    b.Property<int?>("Grado");

                    b.Property<int?>("estudianteStudentID");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("estudianteStudentID");

                    b.ToTable("Inscripcion");
                });

            modelBuilder.Entity("MvcRelaciones.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("StudentID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("MvcRelaciones.Models.Inscripcion", b =>
                {
                    b.HasOne("MvcRelaciones.Models.Course", "curso")
                        .WithMany("Inscripciones")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcRelaciones.Models.Student", "estudiante")
                        .WithMany("Inscripcions")
                        .HasForeignKey("estudianteStudentID");
                });
#pragma warning restore 612, 618
        }
    }
}
