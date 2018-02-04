using CooperativeEshop.Core.Domain;
using System.Collections.Generic;

namespace CooperativeEshop.Models.ViewModels
{
    public class ProductCreationViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<InventoryItem> InventoryItems { get; set; }
    }
}
