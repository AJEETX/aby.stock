﻿using System;
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

        public string ExpenseDate { get; set; }
    }
}