using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Models.ViewModels;
using System.Threading.Tasks;

namespace CooperativeEshop.Controllers
{
    public class AdminUsersController : Controller
    {
        
        private UserManager<AppUser> _userManager;
       

        public AdminUsersController(UserManager<AppUser> userManager)
        {
            
            _userManager = userManager;
        }

        public ViewResult AllUsers() => View(new AdminUsersViewModel
        {
            AllUsers = _userManager.Users
        });

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



    }
}
