using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Data.Entity
{
    public class ServiceCategory : BaseEntity
    {
        public string ServiceCategoryName { get; set; }
        public virtual ICollection<ServiceReport> ServiceReport { get; set; }
    }
}