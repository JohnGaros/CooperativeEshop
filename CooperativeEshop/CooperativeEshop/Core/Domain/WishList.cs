using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class WishList
    {
        public int WishListID { get; set; }

        public AppUser Customer { get; set; }
        public string CustomerID { get; set; }
    }
}
