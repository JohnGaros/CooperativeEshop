using CooperativeEshop.Core.Repositories;
using System.Collections.Generic;
using CooperativeEshop.Core.Domain;


namespace CooperativeEshop.Models.ViewModels
{
    public class AdminPendingProductsViewModel
    {
        public List<AppUser> Sellers { get; set; }

        public IEnumerable<InventoryItem> PendingInventoryItems { get; set; }
        public IInventoryItemRepository InventoryItemRepository { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public int InventoryItemID { get; set; }
        public bool GoLive { get; set; }

        public IPriceComponentRepository PriceComponentRepository { get; set; }
        public decimal SalePrice { get; set; }

        
        
    }
}
