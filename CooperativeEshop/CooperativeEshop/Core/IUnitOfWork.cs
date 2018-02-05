using System;
using CooperativeEshop.Core.Repositories;

namespace CooperativeEshop.Core
{
    public interface IUnitOfWork 
    {
        IProductRepository Products { get; set; }
        IInventoryItemRepository InventoryItems { get; set; }
        IPriceComponentRepository PriceComponents { get; set; }
        
    }
}
