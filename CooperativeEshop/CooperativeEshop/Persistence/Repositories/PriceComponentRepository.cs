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

        public IQueryable<PriceComponent> PriceComponents => ctx.PriceComponents;

        public void AddPriceComponent(PriceComponent priceComponent)
        {
            ctx.PriceComponents.Add(priceComponent);
            ctx.SaveChanges();
        }

        public void UpdatePriceComponent(PriceComponent priceComponent)
        {
            ctx.Update(priceComponent);
            ctx.SaveChanges();
        }

        public void DeletePriceComponent(int PriceComponentID)
        {
            PriceComponent toBeDeleted = ctx.PriceComponents.FirstOrDefault(x => x.PriceComponentID == PriceComponentID);
            if(toBeDeleted != null)
            {
                ctx.PriceComponents.Remove(toBeDeleted);
                ctx.SaveChanges();
            }           
        }
    }
}
