﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Configurations;
using Aby.StockManager.Data.Entity;
using Aby.StockManager.Data.Seed;

namespace Aby.StockManager.Data.Context
{
    public class EasyStockManagerDbContext : DbContext
    {
        public EasyStockManagerDbContext(DbContextOptions<EasyStockManagerDbContext> options) : base(options)
        {
        }

        public DbSet<ServiceCategory> ServiceCategory { get; set; }
        public DbSet<ServiceReport> ServiceReport { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public DbSet<Tax> Tax { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<StoreStock> StoreStock { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionDetail> TransactionDetail { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public virtual DbSet<ExpenseReport> ExpenseReport { get; set; }
        public virtual DbSet<NumberSequence> NumberSequence { get; set; }
        public virtual DbSet<InvoiceNumberSequence> InvoiceNumberSequence { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceReportConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TaxConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseReportConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new StoreStockConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionDetailConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnitOfMeasureConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeSeed());
            modelBuilder.ApplyConfiguration(new UnitOfMeasureSeed());
            modelBuilder.ApplyConfiguration(new CategorySeed());
            modelBuilder.ApplyConfiguration(new ExpenseCategorySeed());
            modelBuilder.ApplyConfiguration(new TaxSeed());
            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new StoreSeed());
            modelBuilder.ApplyConfiguration(new ServiceCategorySeed());
            //modelBuilder.ApplyConfiguration(new ProductSeed());
        }
    }
}