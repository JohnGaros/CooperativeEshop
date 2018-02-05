using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class ProductPriceComponents
    {
        public int PriceComponentID { get; set; }

        public AppUser Seller { get; set; }
        public Product Product { get; set; }

        public decimal BasePrice { get; set; }
        public decimal Surcharge { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
    }
}
