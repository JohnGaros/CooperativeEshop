using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class Order
    {
        public int OrderID { get; set; }

        public Cart Cart { get; set; }
        public int CartID { get; set; }

        public DateTime OrderDate { get; set; }

    }
}
