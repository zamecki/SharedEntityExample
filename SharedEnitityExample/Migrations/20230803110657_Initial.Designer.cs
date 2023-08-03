﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SharedEnitityExample.Migrations
{
    [DbContext(typeof(ExampleDbContext))]
    [Migration("20230803110657_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseEntities.CommonPersonProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique()
                        .HasFilter("[UserAccountId] IS NOT NULL");

                    b.ToTable("PeopleProfiles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CommonPersonProfile");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BaseEntities.CommonUserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CommonUserAccount");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmployeeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PersonProfile", b =>
                {
                    b.HasBaseType("BaseEntities.CommonPersonProfile");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PersonProfile");
                });

            modelBuilder.Entity("UserAccount", b =>
                {
                    b.HasBaseType("BaseEntities.CommonUserAccount");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("EmployeeId");

                    b.HasDiscriminator().HasValue("UserAccount");
                });

            modelBuilder.Entity("BaseEntities.CommonPersonProfile", b =>
                {
                    b.HasOne("BaseEntities.CommonUserAccount", "UserAccount")
                        .WithOne("PersonProfile")
                        .HasForeignKey("BaseEntities.CommonPersonProfile", "UserAccountId");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("UserAccount", b =>
                {
                    b.HasOne("Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BaseEntities.CommonUserAccount", b =>
                {
                    b.Navigation("PersonProfile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
