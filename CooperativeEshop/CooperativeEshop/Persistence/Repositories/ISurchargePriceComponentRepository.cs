using CooperativeEshop.Core.Domain;
using System.Linq;


namespace CooperativeEshop.Persistence.Repositories
{
    public interface ISurchargePriceComponentRepository
    {
        IQueryable<SurchargePriceComponent> SurchargePriceComponents { get; }
        void AddSurchargePriceComponent(SurchargePriceComponent surchargeComponent);
        void UpdateSurchargePriceComponent(SurchargePriceComponent surchargeComponent);
        void DeleteSurchargePriceComponent(int PriceComponentID);
    }
}
