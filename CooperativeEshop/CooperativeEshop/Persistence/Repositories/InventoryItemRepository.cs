using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using System.Linq;

namespace CooperativeEshop.Persistence.Repositories
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        public CoopEshopContext ctx;

        public InventoryItemRepository(CoopEshopContext context)
        {
            ctx = context;
        }

        public IQueryable<InventoryItem> InventoryItems => ctx.InventoryItems;

        public void UpdateInventoryItem(InventoryItem item)
        {
            ctx.Update(item);
            ctx.SaveChanges();
        }
        public void AddInventoryItem(InventoryItem item)
        {            
            ctx.InventoryItems.Add(item);
            ctx.SaveChanges();
        }
        public void DeleteInventoryItem(int itemID)
        {

            InventoryItem toBeDeleted = ctx.InventoryItems.FirstOrDefault(p => p.IneventoryItemID == itemID);
            if (toBeDeleted != null)
            {
                ctx.InventoryItems.Remove(toBeDeleted);
                ctx.SaveChanges();
            }
        }

    }
}
