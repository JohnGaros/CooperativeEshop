using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<InventoryItem> InventoryItems { get; set; }

        public IEnumerable<PriceComponent> PriceComponents { get; set; }
        public IEnumerable<BasePriceComponent> BasePriceComponents { get; set; }
        public IEnumerable<SurchargePriceComponent> SurchargePriceComponents { get; set; }
    }
}
