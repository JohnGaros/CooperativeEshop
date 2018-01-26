using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class BasePriceComponent
    {
        public PriceComponent PriceComponent { get; set; }
        public int PriceComponentID { get; set; }

        public decimal BasePrice { get; set; }
    }
}
