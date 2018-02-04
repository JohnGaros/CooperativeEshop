using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Persistence.Repositories;
using CooperativeEshop.Models.ViewModels;


namespace CooperativeEshop.Controllers
{
    public class AdminProductsController : Controller
    {
        private IProductRepository _repo;

        public AdminProductsController(IProductRepository repo)
        {
            _repo = repo;    
        }

        public ViewResult AllProducts()
        {
            return View(
                new ProductListViewModel
                {
                    Products = _repo.Products
                });
                
        }

        //public IActionResult AddProduct(string name)
        //{
            
        //}
    }
}
