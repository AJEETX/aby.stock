﻿// <auto-generated />
using System;
using Aby.StockManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AbyStockManager.Web.Migrations
{
    [DbContext(typeof(EasyStockManagerDbContext))]
    partial class EasyStockManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "2 wheeler",
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5619)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "4 wheeler",
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5621)
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Heavy Vehicle",
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5623)
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Tractor",
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5625)
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Other",
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5627)
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double?>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double?>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TaxId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitOfMeasureId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TaxId");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Barcode = "test",
                            CategoryId = 1,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(6458),
                            ProductName = "test",
                            PurchasePrice = 100.0,
                            SalePrice = 110.0,
                            TaxId = 1,
                            UnitOfMeasureId = 1
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gstin")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Store", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contact = "+91 70202 53920",
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(6385),
                            Gstin = "09AFLPT3786Q1Z5",
                            Image = "logo.png",
                            StoreCode = "76 Jasuri GT Road Chandauli UP, 232104",
                            StoreName = "SDA Chandauli"
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.StoreStock", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinStock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("StoreId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("StoreStock", (string)null);
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<double>("Rate")
                        .HasMaxLength(6)
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Tax", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5695),
                            Name = "FIRST",
                            Rate = 18.0
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5697),
                            Name = "SECOND",
                            Rate = 28.0
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gstin")
                        .HasColumnType("TEXT");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("StoreId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ToStoreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TransactionCode")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("ToStoreId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.TransactionDetail", b =>
                {
                    b.Property<int>("TransactionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.HasKey("TransactionId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("TransactionDetail", (string)null);
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TransactionTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TransactionType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5287),
                            TransactionTypeName = "Stock In"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5338),
                            TransactionTypeName = "Stock Out"
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.UnitOfMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Isocode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.Property<string>("UnitOfMeasureName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UnitOfMeasure");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5545),
                            Isocode = "pc",
                            UnitOfMeasureName = "Piece"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5550),
                            Isocode = "kg",
                            UnitOfMeasureName = "Kilogram"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(5554),
                            Isocode = "m",
                            UnitOfMeasureName = "Meter"
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(6261),
                            Email = "jag@sda.com",
                            Name = "Jagdeesh",
                            Password = "E18D20C33FC1860873B0AB34A1915F138D6134141B9BF6A4310340ED2F2D92DF",
                            Surname = "Tiwari"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 6, 25, 13, 26, 25, 639, DateTimeKind.Local).AddTicks(6309),
                            Email = "sarb@sda.com",
                            Name = "Sarbjeet",
                            Password = "5994471ABB01112AFCC18159F6CC74B4F511B99806DA59B3CAF5A9C173CACFC5",
                            Surname = "Tiwari"
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Product", b =>
                {
                    b.HasOne("Aby.StockManager.Data.Entity.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Aby.StockManager.Data.Entity.Tax", "Tax")
                        .WithMany("Product")
                        .HasForeignKey("TaxId");

                    b.HasOne("Aby.StockManager.Data.Entity.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("Product")
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Tax");

                    b.Navigation("UnitOfMeasure");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.StoreStock", b =>
                {
                    b.HasOne("Aby.StockManager.Data.Entity.Product", "Product")
                        .WithMany("StoreStock")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aby.StockManager.Data.Entity.Store", "Store")
                        .WithMany("StoreStock")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Transaction", b =>
                {
                    b.HasOne("Aby.StockManager.Data.Entity.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aby.StockManager.Data.Entity.Store", "ToStore")
                        .WithMany()
                        .HasForeignKey("ToStoreId");

                    b.HasOne("Aby.StockManager.Data.Entity.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("ToStore");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.TransactionDetail", b =>
                {
                    b.HasOne("Aby.StockManager.Data.Entity.Product", "Product")
                        .WithMany("TransactionDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aby.StockManager.Data.Entity.Transaction", "Transaction")
                        .WithMany("TransactionDetail")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Product", b =>
                {
                    b.Navigation("StoreStock");

                    b.Navigation("TransactionDetail");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Store", b =>
                {
                    b.Navigation("StoreStock");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Tax", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Transaction", b =>
                {
                    b.Navigation("TransactionDetail");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.UnitOfMeasure", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
