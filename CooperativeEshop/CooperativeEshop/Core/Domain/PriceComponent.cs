using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class PriceComponent
    {
        public int PriceComponentID { get; set; }

        public AppUser Seller { get; set; }
        public Product Product { get; set; }

        public BasePriceComponent BasePrice { get; set; }
        public SurchargePriceComponent Surcharge { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
    }
}
