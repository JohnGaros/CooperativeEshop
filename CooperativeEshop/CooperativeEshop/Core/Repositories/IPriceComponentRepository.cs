using CooperativeEshop.Core.Domain;
using System.Linq;

namespace CooperativeEshop.Core.Repositories
{
    public interface IPriceComponentRepository
    {
        IQueryable<ProductPriceComponents> PriceComponents { get; }
        void AddPriceComponent(ProductPriceComponents priceComponent);
        void UpdatePriceComponent(ProductPriceComponents priceComponent);
        void DeletePriceComponent(int PriceComponentID);
    }
}
