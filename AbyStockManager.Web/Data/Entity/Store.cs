﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Data.Entity
{
    public class Store : BaseEntity
    {
        public string StoreName { get; set; }
        public string StoreCode { get; set; }
        public string Contact { get; set; }
        public string Gstin { get; set; }
        public string Image { get; set; }
        public virtual ICollection<StoreStock> StoreStock { get; set; }
    }
}