using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.Domain
{
    public class TaxDTO : BaseDTO
    {
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}