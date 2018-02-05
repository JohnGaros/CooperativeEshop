using CooperativeEshop.Models.ViewModels;
using CooperativeEshop.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Core;

namespace CooperativeEshop.Controllers
{
   
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
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