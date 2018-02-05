using System.Linq;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;

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
    }
}
