using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class Cart
    {
        public int CartID { get; set; }

        public AppUser Customer { get; set; }
        public string CustomerID { get; set; }
    }
}
