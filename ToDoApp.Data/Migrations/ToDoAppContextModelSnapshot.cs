﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Data;

namespace ToDoApp.Data.Migrations
{
    [DbContext(typeof(ToDoAppContext))]
    partial class ToDoAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RolePlayManager.Api.Data.Entities.RefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("Token");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidUntil");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", "ToDoApp");
                });

            modelBuilder.Entity("ToDoApp.Data.Entities.Task", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinished")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsFinished");

                    b.Property<string>("TaskContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Active");

                    b.Property<string>("ToDoId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("ToDoId");

                    b.ToTable("Task", "ToDoApp");
                });

            modelBuilder.Entity("ToDoApp.Data.Entities.ToDo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Title");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ToDo", "ToDoApp");
                });

            modelBuilder.Entity("ToDoApp.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("AccountCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("AccountCreated")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Active");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User", "ToDoApp");
                });

            modelBuilder.Entity("RolePlayManager.Api.Data.Entities.RefreshToken", b =>
                {
                    b.HasOne("ToDoApp.Data.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDoApp.Data.Entities.Task", b =>
                {
                    b.HasOne("ToDoApp.Data.Entities.ToDo", "ToDo")
                        .WithMany("Tasks")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDo");
                });

            modelBuilder.Entity("ToDoApp.Data.Entities.ToDo", b =>
                {
                    b.HasOne("ToDoApp.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDoApp.Data.Entities.ToDo", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ToDoApp.Data.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
