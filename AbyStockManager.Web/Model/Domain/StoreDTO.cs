﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.Domain
{
    public class StoreDTO : BaseDTO
    {
        public string StoreName { get; set; }
        public string StoreCode { get; set; }
        public string Contact { get; set; }
        public string Gstin { get; set; }
        public string Image { get; set; }
    }
}