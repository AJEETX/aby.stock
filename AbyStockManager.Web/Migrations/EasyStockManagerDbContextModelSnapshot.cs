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
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(412)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "4 wheeler",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(414)
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Heavy Vehicle",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(416)
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Tractor",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(417)
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Other",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(419)
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExpenseCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Snacks",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(611)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Rent",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(615)
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Travel",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(617)
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Utilities",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(618)
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Water",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(620)
                        },
                        new
                        {
                            Id = 6,
                            CategoryName = "Wage",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(621)
                        },
                        new
                        {
                            Id = 7,
                            CategoryName = "Other",
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(623)
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.ExpenseReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CategoryId")
                        .HasMaxLength(50)
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ExpenseReport", (string)null);
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.InvoiceNumberSequence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LastNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberSequenceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumberSequenceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InvoiceNumberSequence");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.NumberSequence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LastNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberSequenceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumberSequenceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NumberSequence");
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
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.ServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceCategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategory", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(1886),
                            ServiceCategoryName = "WHEEL-ALIGNMENT"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(1888),
                            ServiceCategoryName = "OTHERS"
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.ServiceReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ServiceCategoryId")
                        .HasMaxLength(50)
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("ServiceReport", (string)null);
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
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(1827),
                            Gstin = "09AFLPT3786Q1Z5",
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
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(700),
                            Name = "FIRST",
                            Rate = 18.0
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(703),
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

                    b.Property<bool>("Igst")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Remarks")
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

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("FinalSalePrice")
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
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(78),
                            TransactionTypeName = "Stock In"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(127),
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
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(313),
                            Isocode = "pc",
                            UnitOfMeasureName = "Piece"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(319),
                            Isocode = "kg",
                            UnitOfMeasureName = "Kilogram"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(323),
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
                            CreateDate = new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(1723),
                            Email = "jag@sda.com",
                            Name = "Jagdeesh Kumar",
                            Password = "E18D20C33FC1860873B0AB34A1915F138D6134141B9BF6A4310340ED2F2D92DF",
                            Surname = "Tiwari"
                        });
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.ExpenseReport", b =>
                {
                    b.HasOne("Aby.StockManager.Data.Entity.ExpenseCategory", "Category")
                        .WithMany("ExpenseReport")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
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

            modelBuilder.Entity("Aby.StockManager.Data.Entity.ServiceReport", b =>
                {
                    b.HasOne("Aby.StockManager.Data.Entity.ServiceCategory", "ServiceCategory")
                        .WithMany("ServiceReport")
                        .HasForeignKey("ServiceCategoryId");

                    b.Navigation("ServiceCategory");
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

            modelBuilder.Entity("Aby.StockManager.Data.Entity.ExpenseCategory", b =>
                {
                    b.Navigation("ExpenseReport");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.Product", b =>
                {
                    b.Navigation("StoreStock");

                    b.Navigation("TransactionDetail");
                });

            modelBuilder.Entity("Aby.StockManager.Data.Entity.ServiceCategory", b =>
                {
                    b.Navigation("ServiceReport");
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
