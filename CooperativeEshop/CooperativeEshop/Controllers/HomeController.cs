using CooperativeEshop.Models.ViewModels;
using CooperativeEshop.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CooperativeEshop.Controllers
{
   
    public class HomeController : Controller
    {
        private IProductRepository _repo;
        private IInventoryItemRepository _inventoryItem;

        public HomeController(IProductRepository repo, IInventoryItemRepository inv)
        {
            _repo = repo;
            _inventoryItem = inv;
        }

        public ViewResult Index()
        {
            return View();
        }

        //public ViewResult Products(ProductListViewModel model)
        //{
        //    model
        //}
    }
}