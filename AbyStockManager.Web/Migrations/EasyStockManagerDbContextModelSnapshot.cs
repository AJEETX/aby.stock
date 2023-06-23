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
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5713)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "4 wheeler",
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5716)
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Heavy Vehicle",
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5718)
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Tractor",
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5721)
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Other",
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5723)
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

                    b.Property<double?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

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
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(6985),
                            Price = 100.0,
                            ProductName = "test",
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

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreCode")
                        .IsRequired()
                        .HasMaxLength(10)
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
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(6886),
                            StoreCode = "SDA",
                            StoreName = "CEAT Tyres"
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.StoreStock", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
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
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5823),
                            Name = "FIRST",
                            Rate = 18.0
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5827),
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

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
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
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5288),
                            TransactionTypeName = "Stock In"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5353),
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
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5584),
                            Isocode = "pc",
                            UnitOfMeasureName = "Piece"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5597),
                            Isocode = "kg",
                            UnitOfMeasureName = "Kilogram"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(5603),
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
                            CreateDate = new DateTime(2023, 6, 23, 12, 3, 20, 367, DateTimeKind.Local).AddTicks(6729),
                            Email = "jag@sda.com",
                            Name = "Jagdeesh",
                            Password = "2cbe7f341eb6aca638a32b77ddedfd4c",
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
