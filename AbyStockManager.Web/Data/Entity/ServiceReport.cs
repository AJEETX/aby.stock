using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

using Aby.StockManager.Data.Entity;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Aby.StockManager.Data.Entity
{
    public class ServiceReport : BaseEntity
    {
        [Required]
        public string ItemName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ServiceDate { get; set; } = DateTime.Now;

        public int? ServiceCategoryId { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }
    }
}