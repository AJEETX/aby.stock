using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Seed
{
    internal class StoreSeed : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(new Store { Id = 1, StoreCode = "76 Jasuri GT Road Chandauli UP, 232104", Contact = "+91 70202 53920", Gstin = "09AFLPT3786Q1Z5", StoreName = "SDA Chandauli", CreateDate = DateTime.Now });
        }
    }
}