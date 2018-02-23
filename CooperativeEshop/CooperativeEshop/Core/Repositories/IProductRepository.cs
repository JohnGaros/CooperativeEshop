
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

        //total stock
        int QuantityAtHand(Product product);

        //Has Gone Live
        bool Live(Product product);

        bool Offered(Product product);

        //decimal MinPrice(Product product);

    }
}
