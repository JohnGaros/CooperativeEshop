using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using System.Collections.Generic;

namespace CooperativeEshop.Models.ViewModels
{
    public class SellerBasePricesViewModel
    {
        public AppUser Seller { get; set; }

        //used to get the list of Seller's inventory items: iterate these to get the base prices using GetBasePrices
        public IEnumerable<InventoryItem> SellerRepository { get; set; }

        //used to get the product name for each inventory item
        public IInventoryItemRepository InventoryItemRepository { get; set; }

        //use the GetBasePrices(inventory item) to get the collection of base prices for the particular inventory item
        public IPriceComponentRepository PriceComponentRepository { get; set; }

        //public decimal BasePrice { get; set; }

    }
}
