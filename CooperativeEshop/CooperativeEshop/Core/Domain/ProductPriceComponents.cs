﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class ProductPriceComponents
    {
        public int PriceComponentID { get; set; }

        public InventoryItem InventoryItem { get; set; }
        public int InventoryItemID { get; set; }

        public decimal BasePrice { get; set; }
        public decimal SalePrice { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
    }
}
