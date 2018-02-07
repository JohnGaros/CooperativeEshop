using CooperativeEshop.Core.Repositories;
using CooperativeEshop.Core.Domain;
using System.Collections.Generic;

namespace CooperativeEshop.Models.ViewModels
{
    public class SellerProductsOfferedViewModel
    {
        public AppUser Seller { get; set; }
        //public IProductRepository ProductRepository { get; set; }
        public IEnumerable<InventoryItem> SellerInventoryItems { get; set; }
    }
}
