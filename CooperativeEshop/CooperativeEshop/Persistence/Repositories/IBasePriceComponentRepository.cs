using System.Linq;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Persistence.Repositories
{
    public interface IBasePriceComponentRepository
    {
        IQueryable<BasePriceComponent> BasePriceComponents { get; }
        void AddBasePriceComponent(BasePriceComponent baseComponent);
        void UpdateBasePriceComponent(BasePriceComponent baseComponent);
        void DeleteBasePriceComponent(int PriceComponentID);
    }
}
