using CooperativeEshop.Core.Domain;
using System;

namespace CooperativeEshop.Core.Domain
{
    public class InventoryItem
    {
        public int IneventoryItemID { get; set; }

        public AppUser Seller { get; set; }
        public string UserID { get; set; }

        public Product Product { get; set; }
        public int ProductID { get; set; }

        public int StockQuantity { get; set; }
        //Represents the date the stock quantity has changed
        public DateTime Date { get; set; }
    }
}
