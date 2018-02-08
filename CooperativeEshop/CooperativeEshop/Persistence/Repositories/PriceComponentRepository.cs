using System.Linq;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CooperativeEshop.Persistence.Repositories
{
    public class PriceComponentRepository : IPriceComponentRepository
    {
        public CoopEshopContext ctx;

        public PriceComponentRepository(CoopEshopContext context)
        {
            ctx = context;
        }

        public IQueryable<ProductPriceComponents> PriceComponents => ctx.ProductPriceComponents;

        public void AddPriceComponent(ProductPriceComponents priceComponent)
        {
            ctx.ProductPriceComponents.Add(priceComponent);
            ctx.SaveChanges();
        }

        public void UpdatePriceComponent(ProductPriceComponents priceComponent)
        {
            ctx.Update(priceComponent);
            ctx.SaveChanges();
        }

        public void DeletePriceComponent(int PriceComponentID)
        {
            ProductPriceComponents toBeDeleted = ctx.ProductPriceComponents.FirstOrDefault(x => x.PriceComponentID == PriceComponentID);
            if(toBeDeleted != null)
            {
                ctx.ProductPriceComponents.Remove(toBeDeleted);
                ctx.SaveChanges();
            }           
        }

        //public IEnumerable<decimal> GetBasePrices(ProductPriceComponents component) => ctx.ProductPriceComponents.Include(x => x.InventoryItem)
        //    .Where(x => x.InventoryItemID == component.InventoryItemID).Select(x => x.BasePrice);

        public IEnumerable<decimal> GetBasePrices(InventoryItem item) => ctx.ProductPriceComponents.Include(x => x.InventoryItem)
            .Where(x => x.InventoryItemID == item.InventoryItemID).Select(x => x.BasePrice);

        //public decimal GetBasePrice(InventoryItem item) => ctx.ProductPriceComponents.Include(x => x.InventoryItem)
        //    .Where(x => x.InventoryItemID == item.InventoryItemID).Select(x => x.BasePrice);
    }
}
  