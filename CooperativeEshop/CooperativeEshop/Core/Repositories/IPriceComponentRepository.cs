using CooperativeEshop.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CooperativeEshop.Core.Repositories
{
    public interface IPriceComponentRepository
    {
        IQueryable<ProductPriceComponents> PriceComponents { get; }
        void AddPriceComponent(ProductPriceComponents priceComponent);
        void UpdatePriceComponent(ProductPriceComponents priceComponent);
        void DeletePriceComponent(int PriceComponentID);

        IEnumerable<decimal> GetBasePrices(ProductPriceComponents component);
    }
}
