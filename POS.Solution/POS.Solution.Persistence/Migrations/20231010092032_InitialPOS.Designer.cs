﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.Solution.Persistence;

#nullable disable

namespace POS.Solution.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231010092032_InitialPOS")]
    partial class InitialPOS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("POS.Solution.Core.Entities.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ChangeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GivenAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("POS.Solution.Core.Entities.InvoiceDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("POS.Solution.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("19b46f77-1357-4e4d-ac50-ec4b10170ed0"),
                            Price = 150000m,
                            ProductName = "IPhone15"
                        },
                        new
                        {
                            Id = new Guid("7b189bce-79bf-4e36-91d3-29fe1d151fea"),
                            Price = 25000m,
                            ProductName = "Xiaomi Note 10 pro"
                        },
                        new
                        {
                            Id = new Guid("f3b26f53-f5de-457c-9a6a-22f14de2fb8a"),
                            Price = 120000m,
                            ProductName = "Samsung S20 Ultra"
                        },
                        new
                        {
                            Id = new Guid("35c5a455-c655-4f1c-a6da-9318266b11ac"),
                            Price = 80000m,
                            ProductName = "Oneplus 8 pro"
                        },
                        new
                        {
                            Id = new Guid("8309c762-801f-407f-ae7f-a9e98ef3159d"),
                            Price = 75000m,
                            ProductName = "Oneplus 8 T"
                        },
                        new
                        {
                            Id = new Guid("a5aba9bb-38c1-4b1e-b09c-6552fd194453"),
                            Price = 100000m,
                            ProductName = "Huawei Mate 40"
                        },
                        new
                        {
                            Id = new Guid("80e1a3cb-9024-4426-8568-19c5ec1e87bf"),
                            Price = 75000m,
                            ProductName = "Moto M3"
                        });
                });

            modelBuilder.Entity("POS.Solution.Core.Entities.InvoiceDetails", b =>
                {
                    b.HasOne("POS.Solution.Core.Entities.Invoice", null)
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("POS.Solution.Core.Entities.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
