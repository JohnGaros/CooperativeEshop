using CooperativeEshop.Core.Domain;
using System.Linq;
using System.Collections.Generic;

namespace CooperativeEshop.Core.Repositories
{
    public interface IInventoryItemRepository
    {
        IEnumerable<InventoryItem> InventoryItems { get; }
        void AddInventoryItem(InventoryItem item);
        void UpdateInventoryItem(InventoryItem item);
        void DeleteInventoryItem(int itemID);

    }
}
