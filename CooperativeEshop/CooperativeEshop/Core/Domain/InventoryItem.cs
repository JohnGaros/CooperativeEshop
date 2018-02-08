using CooperativeEshop.Core.Domain;
using System;
using System.Collections.Generic;

namespace CooperativeEshop.Core.Domain
{
    public class InventoryItem
    {
        public int InventoryItemID { get; set; }

        public ICollection<ProductPriceComponents> ProductPriceComponents { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

        public AppUser Seller { get; set; }
        public string UserID { get; set; }

        public Product Product { get; set; }
        public int ProductID { get; set; }

        public int StockQuantity { get; set; }
        public bool GoLive { get; set; } = false;
    }
}
