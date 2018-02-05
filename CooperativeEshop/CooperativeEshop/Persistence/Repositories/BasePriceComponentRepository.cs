using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using System.Linq;

namespace CooperativeEshop.Persistence.Repositories
{
    public class BasePriceComponentRepository : IBasePriceComponentRepository
    {
        public CoopEshopContext ctx;

        public BasePriceComponentRepository(CoopEshopContext context)
        {
            ctx = context;
        }

        public IQueryable<BasePriceComponent> BasePriceComponents => ctx.BasePriceComponents;

        public void AddBasePriceComponent(BasePriceComponent baseComponent)
        {
            ctx.BasePriceComponents.Add(baseComponent);
            ctx.SaveChanges();
        }
        public void UpdateBasePriceComponent(BasePriceComponent baseComponent)
        {
            ctx.Update(baseComponent);
            ctx.SaveChanges();
        }

        public void DeleteBasePriceComponent(int PriceComponentID)
        {
            BasePriceComponent baseComponent = ctx.BasePriceComponents.FirstOrDefault(x => x.PriceComponentID == PriceComponentID);
            ctx.Remove(baseComponent);
            ctx.SaveChanges();
        }
    }
}
