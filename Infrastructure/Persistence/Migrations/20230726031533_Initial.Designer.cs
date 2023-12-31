﻿// <auto-generated />
using System;
using Grupo3_Unapec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Grupo3_Unapec.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230726031533_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AreaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Course")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TitleConfigurationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TitleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("TitleConfigurationId");

                    b.HasIndex("TitleId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AreaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("SubjectSubject", b =>
                {
                    b.Property<int>("IncompatiblesSubjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IncompatiblesSubjectsId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("IncompatibleSubject", (string)null);
                });

            modelBuilder.Entity("SubjectSubject1", b =>
                {
                    b.Property<int>("PreRequiredSubjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredForSubjectsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PreRequiredSubjectsId", "RequiredForSubjectsId");

                    b.HasIndex("RequiredForSubjectsId");

                    b.ToTable("RequiredSubject", (string)null);
                });

            modelBuilder.Entity("SubjectSubject2", b =>
                {
                    b.Property<int>("EquivalentSubjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Subject1Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("EquivalentSubjectsId", "Subject1Id");

                    b.HasIndex("Subject1Id");

                    b.ToTable("EquivalentSubject", (string)null);
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeachersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Area", b =>
                {
                    b.HasOne("Grupo3_Unapec.Domain.Entities.Department", "Department")
                        .WithMany("Areas")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Subject", b =>
                {
                    b.HasOne("Grupo3_Unapec.Domain.Entities.Area", "Area")
                        .WithMany("Subjects")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Grupo3_Unapec.Domain.Entities.Title", "TitleConfiguration")
                        .WithMany("ConfigurationSubjects")
                        .HasForeignKey("TitleConfigurationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Grupo3_Unapec.Domain.Entities.Title", "Title")
                        .WithMany("Subjects")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Grupo3_Unapec.Domain.ValueObjects.Credits", "Credits", b1 =>
                        {
                            b1.Property<int>("SubjectId")
                                .HasColumnType("INTEGER");

                            b1.Property<float>("Laboratory")
                                .HasColumnType("REAL");

                            b1.Property<float>("Theoretical")
                                .HasColumnType("REAL");

                            b1.HasKey("SubjectId");

                            b1.ToTable("Subject");

                            b1.WithOwner()
                                .HasForeignKey("SubjectId");
                        });

                    b.OwnsOne("Grupo3_Unapec.Domain.ValueObjects.SubjectCode", "Code", b1 =>
                        {
                            b1.Property<int>("SubjectId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("Number")
                                .HasColumnType("INTEGER");

                            b1.HasKey("SubjectId");

                            b1.ToTable("Subject");

                            b1.WithOwner()
                                .HasForeignKey("SubjectId");
                        });

                    b.Navigation("Area");

                    b.Navigation("Code")
                        .IsRequired();

                    b.Navigation("Credits")
                        .IsRequired();

                    b.Navigation("Title");

                    b.Navigation("TitleConfiguration");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("Grupo3_Unapec.Domain.Entities.Area", "Area")
                        .WithMany("Teachers")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Grupo3_Unapec.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("TeacherId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("TeacherId");

                            b1.ToTable("Teacher");

                            b1.WithOwner()
                                .HasForeignKey("TeacherId");
                        });

                    b.OwnsOne("Grupo3_Unapec.Domain.ValueObjects.Office", "Office", b1 =>
                        {
                            b1.Property<int>("TeacherId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("Number")
                                .HasColumnType("INTEGER");

                            b1.HasKey("TeacherId");

                            b1.ToTable("Teacher");

                            b1.WithOwner()
                                .HasForeignKey("TeacherId");
                        });

                    b.OwnsMany("Grupo3_Unapec.Domain.ValueObjects.Schedule", "Schedules", b1 =>
                        {
                            b1.Property<int>("TeacherId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Day")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<TimeOnly>("FromTime")
                                .HasColumnType("TEXT");

                            b1.Property<TimeOnly>("ToTime")
                                .HasColumnType("TEXT");

                            b1.HasKey("TeacherId", "Id");

                            b1.ToTable("Schedule");

                            b1.WithOwner()
                                .HasForeignKey("TeacherId");
                        });

                    b.Navigation("Area");

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("SubjectSubject", b =>
                {
                    b.HasOne("Grupo3_Unapec.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("IncompatiblesSubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Grupo3_Unapec.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectSubject1", b =>
                {
                    b.HasOne("Grupo3_Unapec.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("PreRequiredSubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Grupo3_Unapec.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("RequiredForSubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectSubject2", b =>
                {
                    b.HasOne("Grupo3_Unapec.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("EquivalentSubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Grupo3_Unapec.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("Subject1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("Grupo3_Unapec.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Grupo3_Unapec.Domain.Entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Area", b =>
                {
                    b.Navigation("Subjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Department", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("Grupo3_Unapec.Domain.Entities.Title", b =>
                {
                    b.Navigation("ConfigurationSubjects");

                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
