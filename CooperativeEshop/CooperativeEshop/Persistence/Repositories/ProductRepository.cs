using System.Linq;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;

using System;
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

        public IEnumerable<Product> Products => ctx.Products;

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

        public bool Live(Product product) => ctx.InventoryItems.Where(x => x.ProductID == product.ProductID).Any(x => x.GoLive == true);
        public bool Offered(Product product) => ctx.InventoryItems.Where(x => x.ProductID == product.ProductID).Any();

        //public decimal MinPrice(Product product)
        //{
        //    IEnumerable<InventoryItem> ProductInventory = ctx.InventoryItems.Where(x => x.Product == product);
        //    List<decimal> totalPrices = new List<decimal>();
        //    if(components == null)
        //    {
        //        return 0M;
        //    }
        //    else
        //    {
        //        foreach (InventoryItem p in ProductInventory)
        //        {
        //            totalPrices.Add(p.SalePrice);
        //        }
        //        return totalPrices.Min();
        //    }
            
            
        //}     
    }
}
