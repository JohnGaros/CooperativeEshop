
using Microsoft.AspNetCore.Mvc;

namespace CooperativeEshop.Controllers
{
   
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Products() => View();
    }
}