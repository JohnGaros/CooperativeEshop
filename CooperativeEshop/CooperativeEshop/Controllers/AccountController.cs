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
            return View(new LoginUserViewModel {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(details.Email);
                if(user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager
                        .PasswordSignInAsync(user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        ViewBag.Welcome = user.UserName.ToString();
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginUserViewModel.Email), "Invalid email or password");
            }
            return View(details);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
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
