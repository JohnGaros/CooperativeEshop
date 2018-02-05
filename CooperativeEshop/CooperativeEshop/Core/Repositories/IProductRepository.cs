
using System.Linq;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Core.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        
    }
}
