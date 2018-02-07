using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Core;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CooperativeEshop.Controllers
{
    [Authorize(Roles ="Seller")]
    public class SellerController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public SellerController(IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public ViewResult ProductsOffered() => View(new SellerProductsViewModel {
            ProductRepository = _unitOfWork.Products,
            InventoryItemRepository = _unitOfWork.InventoryItems,
            PriceComponentRepository = _unitOfWork.PriceComponents
        });

        public ViewResult ProductNewOffer() => View(new SellerProductsViewModel {
            ProductRepository = _unitOfWork.Products
           
        });

        [HttpPost]
        public async Task<IActionResult> ProductNewOffer(SellerProductsViewModel model)
        {
            InventoryItem item = new InventoryItem
            {
                Product = _unitOfWork.Products.Products.FirstOrDefault(x => x.Name == model.ProductName),
                Seller = await _userManager.FindByNameAsync("Seller"),
                StockQuantity = model.InventoryItem.StockQuantity,
                GoLive = false
            };
            _unitOfWork.InventoryItems.AddInventoryItem(item);
            return RedirectToAction(nameof(ProductsOffered));
        }
    }
}
