using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Persistence.Repositories;
using CooperativeEshop.Models.ViewModels;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using System.ComponentModel.DataAnnotations;

namespace CooperativeEshop.Controllers
{
    public class AdminProductsController : Controller
    {
        private IProductRepository _repo;
        private IInventoryItemRepository _inventoryItem;

        public AdminProductsController(IProductRepository repo, IInventoryItemRepository inv)
        {
            _repo = repo;
            _inventoryItem = inv;
        }

        public ViewResult AllProducts()
        {
            return View(
                new ProductListViewModel
                {
                    Products = _repo.Products
                });
                
        }
        
        public IActionResult CreateProduct() => View();

        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel newProduct)
        {
            Product product = newProduct.Product;
            product.CoverFilePath = $"/Images/" + newProduct.Product.CoverFilePath;
            _repo.AddProduct(product);
            return RedirectToAction(nameof(CreateProduct));
        }

        [HttpPost]
        public IActionResult DeleteProduct(int ProductID)
        {
            _repo.DeleteProduct(ProductID);
            return RedirectToAction(nameof(AllProducts));
        }
    }
}
