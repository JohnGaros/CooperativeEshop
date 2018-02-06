using CooperativeEshop.Core.Repositories;
using CooperativeEshop.Core.Domain;
using System.Collections.Generic;
using System.Linq;
namespace CooperativeEshop.Models.ViewModels
{
    public class ProductCardViewModel
    {
        public string ProductName { get; set; }
        public string CoverFile { get; set; }
        public decimal MinPrice { get; set; }        
    }
}
