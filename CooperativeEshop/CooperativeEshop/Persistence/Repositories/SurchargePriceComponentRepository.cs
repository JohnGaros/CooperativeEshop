using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using System.Linq;


namespace CooperativeEshop.Persistence.Repositories
{
    public class SurchargePriceComponentRepository : ISurchargePriceComponentRepository
    {
        public CoopEshopContext ctx;

        public SurchargePriceComponentRepository(CoopEshopContext context)
        {
            ctx = context;
        }

        public IQueryable<SurchargePriceComponent> SurchargePriceComponents => ctx.SurchargePriceComponents;

        public void AddSurchargePriceComponent(SurchargePriceComponent surchargeComponent)
        {
            ctx.SurchargePriceComponents.Add(surchargeComponent);
            ctx.SaveChanges();
        }
        public void UpdateSurchargePriceComponent(SurchargePriceComponent surchargeComponent)
        {
            ctx.Update(surchargeComponent);
            ctx.SaveChanges();
        }

        public void DeleteSurchargePriceComponent(int PriceComponentID)
        {
            SurchargePriceComponent surchargeComponent = ctx.SurchargePriceComponents.FirstOrDefault(x => x.PriceComponentID == PriceComponentID);
            ctx.Remove(surchargeComponent);
            ctx.SaveChanges();
        }
    }
}
