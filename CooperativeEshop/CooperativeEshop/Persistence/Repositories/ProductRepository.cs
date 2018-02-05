using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public CoopEshopContext ctx;

        public ProductRepository(CoopEshopContext context)
        {
            ctx = context;
        }

        public IQueryable<Product> Products => ctx.Products;

        public void UpdateProduct(Product product)
        {
            ctx.Update(product);
            ctx.SaveChanges();
        }
        public void AddProduct (Product product)
        {
           
            ctx.Products.Add(product);
            ctx.SaveChanges();
        }
        public void DeleteProduct(int ProductID)
        {

            Product toBeDeleted = ctx.Products.FirstOrDefault(p => p.ProductID == ProductID);
            if (toBeDeleted != null)
            {
                ctx.Products.Remove(toBeDeleted);
                ctx.SaveChanges();
            }
        }
    }
}
