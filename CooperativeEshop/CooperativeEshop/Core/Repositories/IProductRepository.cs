
using System.Collections.Generic;
using System.Linq;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);

        int QuantityAtHand(Product product);
        //decimal MinPrice(Product product);

    }
}
