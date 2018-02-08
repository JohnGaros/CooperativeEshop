using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Models.ViewModels;
using System.Threading.Tasks;
using CooperativeEshop.Core;
using System.Collections.Generic;

namespace CooperativeEshop.Controllers
{
    public class AdminUsersController : Controller
    {
        
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public AdminUsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public ViewResult AllUsers() => View(new AdminUsersViewModel
        {
            AllUsers = _userManager.Users
        });

        public async Task<IActionResult> AllSellers()
        {
            var users = _userManager.Users;
            List<AppUser> AllSellers = new List<AppUser>();
            foreach(AppUser user in users)
            {
                if(await _userManager.IsInRoleAsync(user, "Seller"))
                {
                    AllSellers.Add(user);
                }
            }
            return View(new AdminSellersViewModel {
                AllSellers = AllSellers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(AllUsers));
                }
                else
                {
                    
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View(nameof(AllUsers));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSellers(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(AllSellers));
                }
                else
                {

                }
            }
            else
            {
                ModelState.AddModelError("", "Seller not found");
            }
            return View(nameof(AllSellers));
        }

    }
}
