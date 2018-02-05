using CooperativeEshop.Persistence.Repositories;
using CooperativeEshop.Core.Repositories;
using CooperativeEshop.Core;

namespace CooperativeEshop.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoopEshopContext ctx;

        public IProductRepository Products { get; set; }
        public IInventoryItemRepository InventoryItems { get; set; }
        public IPriceComponentRepository PriceComponents { get; set; }


        public UnitOfWork(CoopEshopContext context)
        {
            ctx = context;

            Products = new ProductRepository(ctx);
            InventoryItems = new InventoryItemRepository(ctx);
            PriceComponents = new PriceComponentRepository(ctx);

        }
    }
}
