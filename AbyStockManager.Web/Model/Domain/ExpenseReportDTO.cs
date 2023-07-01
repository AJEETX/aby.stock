using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aby.StockManager.Model.Domain
{
    public class ExpenseReportDTO : BaseDTO
    {
        public string ItemName { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpenseDate { get; set; }
    }
}