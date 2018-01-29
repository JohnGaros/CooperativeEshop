using Microsoft.AspNetCore.Mvc;


namespace CooperativeEshop.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Register() => View();

        public ViewResult SignIn() => View();
    }
}
