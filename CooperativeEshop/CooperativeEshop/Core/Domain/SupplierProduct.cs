﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class SupplierProduct
    {
        public Product Product { get; set; }
        public int ProductID { get; set; }

        public AppUser Seller { get; set; }
        public string UserID { get; set; }

        public int StockQuantity { get; set; }
    }
}
