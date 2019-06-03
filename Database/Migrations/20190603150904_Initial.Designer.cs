﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(PaperWorkerDbContext))]
    [Migration("20190603150904_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.Models.Account.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = new Guid("aba45201-df85-44b5-bf6c-18c88a53bcdf"), Name = "Consumer" },
                        new { Id = new Guid("80e1eac8-73c1-4521-b7b1-d17432863986"), Name = "Locksmith" },
                        new { Id = new Guid("c112f70e-1a4b-4abf-86b2-dcbd9b78b37b"), Name = "Admin" }
                    );
                });

            modelBuilder.Entity("Database.Models.Account.User", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<Guid>("ProfileId");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"), Email = "Zhelonkin.ru@yandex.ru", Password = "123", ProfileId = new Guid("00000000-0000-0000-0000-000000000000"), Status = "Confirmed" }
                    );
                });

            modelBuilder.Entity("Database.Models.Account.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new { UserId = new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"), RoleId = new Guid("aba45201-df85-44b5-bf6c-18c88a53bcdf") },
                        new { UserId = new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"), RoleId = new Guid("80e1eac8-73c1-4521-b7b1-d17432863986") },
                        new { UserId = new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"), RoleId = new Guid("c112f70e-1a4b-4abf-86b2-dcbd9b78b37b") }
                    );
                });

            modelBuilder.Entity("Database.Models.Addressing.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<Guid>("StructureId");

                    b.HasKey("Id");

                    b.HasIndex("StructureId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Database.Models.Addressing.Locality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("TerritoryId");

                    b.HasKey("Id");

                    b.HasIndex("TerritoryId");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Database.Models.Addressing.Street", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<Guid>("LocalityId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("Database.Models.Addressing.Structure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<Guid>("StreetId");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("Structures");
                });

            modelBuilder.Entity("Database.Models.Addressing.Territory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Territories");
                });

            modelBuilder.Entity("Database.Models.Consumer", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("AddressId");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("PersonalNumber");

                    b.Property<Guid>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("Database.Models.EmailMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<byte>("Type");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailMessages");
                });

            modelBuilder.Entity("Database.Models.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Patronymic");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.HasData(
                        new { Id = new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"), FirstName = "Саня", LastName = "Желонкин", Patronymic = "Викторович", PhoneNumber = "+7 927 298 32 49" }
                    );
                });

            modelBuilder.Entity("Database.Models.Account.User", b =>
                {
                    b.HasOne("Database.Models.Profile", "Profile")
                        .WithOne()
                        .HasForeignKey("Database.Models.Account.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Account.UserRole", b =>
                {
                    b.HasOne("Database.Models.Account.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Database.Models.Account.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Addressing.Address", b =>
                {
                    b.HasOne("Database.Models.Addressing.Structure", "Structure")
                        .WithMany("Addresses")
                        .HasForeignKey("StructureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Addressing.Locality", b =>
                {
                    b.HasOne("Database.Models.Addressing.Territory", "Territory")
                        .WithMany("Localities")
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Addressing.Street", b =>
                {
                    b.HasOne("Database.Models.Addressing.Locality", "Locality")
                        .WithMany("Streets")
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Addressing.Structure", b =>
                {
                    b.HasOne("Database.Models.Addressing.Street", "Street")
                        .WithMany("Structures")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Addressing.Territory", b =>
                {
                    b.HasOne("Database.Models.Addressing.Territory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Database.Models.Consumer", b =>
                {
                    b.HasOne("Database.Models.Addressing.Address", "Address")
                        .WithMany("Consumers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Database.Models.Profile", "Profile")
                        .WithOne()
                        .HasForeignKey("Database.Models.Consumer", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.EmailMessage", b =>
                {
                    b.HasOne("Database.Models.Account.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
