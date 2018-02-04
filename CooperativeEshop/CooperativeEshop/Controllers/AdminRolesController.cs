using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CooperativeEshop.Models.ViewModels;
using CooperativeEshop.Core.Domain;
using Microsoft.AspNetCore.Authorization;

namespace CooperativeEshop.Controllers
{
    public class AdminRolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public AdminRolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public ViewResult AllRoles() => View(_roleManager.Roles);

        public IActionResult CreateRole() => View();
       
        [HttpPost]
        public async Task<IActionResult> CreateRole([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(AllRoles));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(name);
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if(role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(AllRoles));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }               
            }
            else
            {
                ModelState.AddModelError("", "No role found");
            }
            return View("AllRoles", _roleManager.Roles);
        }

        [Authorize]
        public IActionResult AddUserToRole() => View();

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRoleViewModel userRole)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(userRole.User.Id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(user, userRole.Role.Name);

                    if (result.Succeeded)
                    {
                        return Redirect("~/Home/Index");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View();

        }

        //[HttpPost]
        //public async Task<RedirectToActionResult> BecomeSeller(string email)
        //{
        //    AppUser user = await _userManager.FindByEmailAsync(email);
        //    IdentityRole role = await _roleManager.FindByNameAsync("Seller");
        //    UserRoleViewModel model = new UserRoleViewModel
        //    {
        //        Role = role,
        //        User = user
        //    };
        //    TempData[UserRoleViewModel model] = model;
        //    View(nameof(AddUserToRole), model);                          
        //}

    }
}
