using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace CooperativeEshop.Persistence.Repositories
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        public CoopEshopContext ctx;

        public InventoryItemRepository(CoopEshopContext context)
        {
            ctx = context;
        }

        public IEnumerable<InventoryItem> InventoryItems => ctx.InventoryItems;

        public void UpdateInventoryItem(InventoryItem item)
        {
            ctx.Update(item);
            ctx.SaveChanges();
        }
        public void AddInventoryItem(AppUser Seller, InventoryItem item)
        {
            item.UserID = Seller.Id;
            ctx.InventoryItems.Add(item);
            ctx.SaveChanges();
        }
        public void DeleteInventoryItem(int itemID)
        {

            InventoryItem toBeDeleted = ctx.InventoryItems.FirstOrDefault(p => p.InventoryItemID == itemID);
            if (toBeDeleted != null)
            {
                ctx.InventoryItems.Remove(toBeDeleted);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<InventoryItem> GetSellerItems(AppUser user)
        {
            return ctx.InventoryItems.Where(x => x.Seller == user);
        }

        public bool IsEmpty(IInventoryItemRepository repo) => !repo.InventoryItems.Any();

        public string GetProductName(InventoryItem item) => ctx.InventoryItems.Include(x => x.Product)
            .FirstOrDefault(x => x.InventoryItemID == item.InventoryItemID).Product.Name;

        public IQueryable<ProductPriceComponents> ItemPriceComponents(InventoryItem item) =>
            ctx.ProductPriceComponents.Include(x => x.InventoryItem).Where(x => x.InventoryItemID == item.InventoryItemID);

        //public decimal GetBasePrice(InventoryItem item) => ctx.InventoryItems.Include(x => x.ProductPriceComponents).Where(x => x.InventoryItemID == item.InventoryItemID)
        //    .FirstOrDefault(x => x.ProductPriceComponents == item.ProductPriceComponents).ProductPriceComponents;
    }
}