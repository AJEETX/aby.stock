using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;
using Aby.StockManager.Common.Extensions;

namespace Aby.StockManager.Data.Seed
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        private string adminPassword = "12345!";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User { Id = 1, Email = "jag@sda.com", Name = "Jagdeesh", Surname = "Tiwari", Password = adminPassword.MD5Hash(), CreateDate = DateTime.Now });
        }
    }
}