using CooperativeEshop.Core.Domain;
using System.Linq;
using System.Collections.Generic;

namespace CooperativeEshop.Core.Repositories
{
    public interface IInventoryItemRepository
    {
        IEnumerable<InventoryItem> InventoryItems { get; }

        void AddInventoryItem(AppUser Seller, InventoryItem item);
        void UpdateInventoryItem(InventoryItem item);
        void DeleteInventoryItem(int itemID);

        //The following are required for the ProductsOffered view
        IEnumerable<InventoryItem> GetSellerItems(AppUser user);
        bool IsEmpty(IInventoryItemRepository repo);
        decimal GetBasePrice(InventoryItem item);
        string GetProductName(InventoryItem item);
    }
}
