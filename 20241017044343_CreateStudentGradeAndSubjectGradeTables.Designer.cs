﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Web.Data;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241017044343_CreateStudentGradeAndSubjectGradeTables")]
    partial class CreateStudentGradeAndSubjectGradeTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("StudentPortal.Web.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Branch")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Semester")
                        .HasColumnType("longtext");

                    b.Property<bool>("Subscribed")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.StudentGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentGrades");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.SubjectGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("StudentGradeId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StudentGradeId");

                    b.ToTable("SubjectGrades");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Branch")
                        .HasColumnType("longtext");

                    b.Property<string>("Semester")
                        .HasColumnType("longtext");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.StudentGrade", b =>
                {
                    b.HasOne("StudentPortal.Web.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.SubjectGrade", b =>
                {
                    b.HasOne("StudentPortal.Web.Models.StudentGrade", "StudentGrade")
                        .WithMany("SubjectGrades")
                        .HasForeignKey("StudentGradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentGrade");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.StudentGrade", b =>
                {
                    b.Navigation("SubjectGrades");
                });
#pragma warning restore 612, 618
        }
    }
}
