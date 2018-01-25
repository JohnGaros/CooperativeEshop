using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class ProductCategoryClassification
    {
        public Product Product { get; set; }
        public int ProductID { get; set; }

        public ProductCategory Category { get; set; }
        public int CategoryID { get; set; }
    }
}
