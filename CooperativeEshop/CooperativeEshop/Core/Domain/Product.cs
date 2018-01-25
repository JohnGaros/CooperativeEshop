using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        public ICollection<SupplierProduct> SupplierProduct { get; }
        public ICollection<ProductCategoryClassification> ProductCategoryClassifications { get; set; }
    }
}
