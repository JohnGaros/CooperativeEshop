using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using CooperativeEshop.Models.ViewModels;

using System.Threading.Tasks;

namespace CooperativeEshop.Controllers
{
    public class AdminController : Controller
    {
        private IUserRepository _userRepository;
        private UserManager<AppUser> _userManager;
       

        public AdminController(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public ViewResult AllUsers() => View(new AdminUsersViewModel
        {
            AllUsers = _userRepository.AppUsers
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
