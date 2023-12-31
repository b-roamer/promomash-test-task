﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = new Guid("2eb8fb8b-7c66-4413-b18f-f25e91ca0809"),
                            CreatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 609, DateTimeKind.Utc).AddTicks(8700),
                            Name = "Kazakhstan",
                            UpdatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 609, DateTimeKind.Utc).AddTicks(8700)
                        },
                        new
                        {
                            CountryId = new Guid("aa2f72aa-303c-45e5-a744-510e9152d83d"),
                            CreatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(3230),
                            Name = "USA",
                            UpdatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(3230)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Province", b =>
                {
                    b.Property<Guid>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProvinceId");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            ProvinceId = new Guid("0e277eba-e766-4bd4-996f-ec4624603f47"),
                            CountryId = new Guid("2eb8fb8b-7c66-4413-b18f-f25e91ca0809"),
                            CreatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(4300),
                            Name = "Almaty",
                            UpdatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(4300)
                        },
                        new
                        {
                            ProvinceId = new Guid("537d09ab-9615-41f4-b4c8-bc4fee49c452"),
                            CountryId = new Guid("2eb8fb8b-7c66-4413-b18f-f25e91ca0809"),
                            CreatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8450),
                            Name = "Astana",
                            UpdatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8450)
                        },
                        new
                        {
                            ProvinceId = new Guid("e56ff022-a741-4545-8132-bc30206b310c"),
                            CountryId = new Guid("aa2f72aa-303c-45e5-a744-510e9152d83d"),
                            CreatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8630),
                            Name = "New York",
                            UpdatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8630)
                        },
                        new
                        {
                            ProvinceId = new Guid("133d9a2d-cee2-4629-bc13-7cab76ae68ff"),
                            CountryId = new Guid("aa2f72aa-303c-45e5-a744-510e9152d83d"),
                            CreatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8640),
                            Name = "Washington",
                            UpdatedDate = new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8640)
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProvinceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Province", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Domain.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");

                    b.Navigation("Country");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Navigation("Provinces");
                });
#pragma warning restore 612, 618
        }
    }
}
