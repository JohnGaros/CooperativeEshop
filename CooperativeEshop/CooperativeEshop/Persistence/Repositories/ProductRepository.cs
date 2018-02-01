using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(CoopEshopContext ctx) : base(ctx)
        {
                
        }
    }
}
