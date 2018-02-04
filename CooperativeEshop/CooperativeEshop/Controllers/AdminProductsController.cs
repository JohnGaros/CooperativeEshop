using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Persistence.Repositories;
using CooperativeEshop.Models.ViewModels;
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
        public IActionResult CreateProduct(string name)
        {
            _repo.AddProduct(name);
            return RedirectToAction(nameof(CreateProduct));
        }
    }
}
