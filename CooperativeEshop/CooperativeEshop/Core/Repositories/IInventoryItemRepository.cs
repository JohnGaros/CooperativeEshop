using CooperativeEshop.Core.Domain;
using System.Linq;

namespace CooperativeEshop.Core.Repositories
{
    public interface IInventoryItemRepository
    {
        IQueryable<InventoryItem> InventoryItems { get; }
        void AddInventoryItem(InventoryItem item);
        void UpdateInventoryItem(InventoryItem item);
        void DeleteInventoryItem(int itemID);

    }
}
