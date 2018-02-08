using CooperativeEshop.Core.Repositories;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Persistence.Repositories;
using System.Collections.Generic;

namespace CooperativeEshop.Models.ViewModels
{
    public class SellerProductsOfferedViewModel
    {
        public AppUser Seller { get; set; }
        public IInventoryItemRepository InventoryItemRepository { get; set; }
        public IEnumerable<InventoryItem> SellerRepository { get; set; }
        public IPriceComponentRepository PriceComponentRepository { get; set; }
        public ProductPriceComponents PriceComponent { get; set; }
    }
}
