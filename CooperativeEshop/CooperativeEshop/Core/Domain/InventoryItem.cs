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
        //Represents the date the stock quantity has changed - 
        //a stock change registers as a new table entry
        public DateTime Date { get; set; }
    }
}
