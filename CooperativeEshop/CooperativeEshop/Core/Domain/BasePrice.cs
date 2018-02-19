using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class BasePrice
    {
        public ProductPriceComponents ProductPriceComponent { get; set; }
        public int PriceComponentID { get; set; }
        
        public decimal basePrice { get; set; }
    }
}
