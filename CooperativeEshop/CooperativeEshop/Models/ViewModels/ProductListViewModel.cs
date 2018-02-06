using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;

namespace CooperativeEshop.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IProductRepository productRepository { get; set; }
    }
}
