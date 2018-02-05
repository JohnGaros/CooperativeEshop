using CooperativeEshop.Core.Domain;
using System.Linq;

namespace CooperativeEshop.Persistence.Repositories
{
    public interface IPriceComponentRepository
    {
        IQueryable<PriceComponent> PriceComponents { get; }
        void AddPriceComponent(PriceComponent priceComponent);
        void UpdatePriceComponent(PriceComponent priceComponent);
        void DeletePriceComponent(int PriceComponentID);
    }
}
