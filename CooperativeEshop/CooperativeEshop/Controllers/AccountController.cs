using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CooperativeEshop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public RedirectResult GoHome() => Redirect("~/Home/Index");


        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginUserViewModel details, string returnUrl)
        {
            return View(details);
        }
        
        [AllowAnonymous]
        public ViewResult CreateUser()
        {
            //ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(CreateUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = newUser.Username,
                    Email = newUser.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);

                if (result.Succeeded)
                {

                    return RedirectToAction(nameof(GoHome));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(newUser);
            
        }

    }
}
