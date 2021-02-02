﻿// <auto-generated />
using FundooRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FundooRepository.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20210202125852_FundooNotes")]
    partial class FundooNotes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FundooModels.LableModel", b =>
                {
                    b.Property<int>("LableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Lable")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NoteId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LableId");

                    b.HasIndex("UserId");

                    b.ToTable("Lables");
                });

            modelBuilder.Entity("FundooModels.NotesModel", b =>
                {
                    b.Property<int>("NotesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Archieve")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Collaborator")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Color")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Image")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Is_Trash")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Lable")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Pin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Reminder")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NotesId");

                    b.HasIndex("UserId");

                    b.ToTable("FundooNotes");
                });

            modelBuilder.Entity("FundooModels.RegistrationModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserFirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FundooModels.LableModel", b =>
                {
                    b.HasOne("FundooModels.RegistrationModel", "RegistrationModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FundooModels.NotesModel", b =>
                {
                    b.HasOne("FundooModels.RegistrationModel", "RegistrationModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
