using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public Cart Cart { get; set; }
        public int CartID { get; set; }

        public Product Product { get; set; }
        public int ProductID { get; set; }

        public AppUser Seller { get; set; }
        public string SellerID { get; set; }

        public int QuantityInCart { get; set; }
        public decimal UnitPrice { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime? DateRemoved { get; set; }

    }
}
