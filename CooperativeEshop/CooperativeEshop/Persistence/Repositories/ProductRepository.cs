using System.Linq;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using System.Collections.Generic;

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

            Product toBeDeleted = ctx.Products.Find(ProductID);
            if (toBeDeleted != null)
            {
                ctx.Products.Remove(toBeDeleted);
                ctx.SaveChanges();
            }
        }

        public int QuantityAtHand(Product product)
        {
            IQueryable<InventoryItem> ProductInventoryItems = ctx.InventoryItems.Where(x => x.ProductID == product.ProductID);
            return ProductInventoryItems.Sum(x => x.StockQuantity);
        }

        //public decimal MinPrice(Product product)
        //{
        //    IQueryable<BasePriceComponent> BasePriceComponents = ctx.BasePriceComponents
        //        .Where(x => x.PriceComponent.Product == product && x.PriceComponent.ThruDate == null);
        //    IQueryable<SurchargePriceComponent> SurchargePriceComponent = ctx.SurchargePriceComponents
        //        .Where(x => x.PriceComponent.Product == product && x.PriceComponent.ThruDate == null);
        //    IQueryable TotalPrices = 

        //}


    }
}
