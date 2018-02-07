using CooperativeEshop.Core.Repositories;
using CooperativeEshop.Core.Domain;


namespace CooperativeEshop.Models.ViewModels
{
    public class SellerProductsViewModel
    {
        public AppUser Seller { get; set; }

        public string ProductName { get; set; }

        public IProductRepository ProductRepository { get; set; }

        public InventoryItem InventoryItem { get; set; }
        public IInventoryItemRepository InventoryItemRepository { get; set; }

        public ProductPriceComponents ProductPriceComponents { get; set; }
        //public IPriceComponentRepository PriceComponentRepository { get; set; }

        //public LoginUserViewModel LoginUserViewModel { get; set; }

    }
}
