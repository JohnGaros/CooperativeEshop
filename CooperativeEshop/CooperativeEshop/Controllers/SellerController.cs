using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Core;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using CooperativeEshop.Core.Repositories;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CooperativeEshop.Persistence.Repositories;

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

        //public IActionResult ProductsOffered(LoginUserViewModel model)
        //{
        //    _seller = _userManager.Users.FirstOrDefault(x => x.Email == model.Email);
        //    return View(new SellerProductsViewModel
        //    {
        //        Seller = _seller,
        //        ProductRepository = _unitOfWork.Products,
        //        InventoryItemRepository = _unitOfWork.InventoryItems
        //    });

        //}

        

        public IActionResult ProductsOffered()
        {
            AppUser seller = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            //InventoryItemRepository SellerInventory = _unitOfWork.InventoryItems.InventoryItems.Where(x => x.Seller == seller);
            SellerProductsOfferedViewModel model = new SellerProductsOfferedViewModel
            {
                Seller = seller,
                SellerRepository = _unitOfWork.InventoryItems.GetSellerItems(seller),
                InventoryItemRepository = _unitOfWork.InventoryItems
            };
            return View(model);
        }

        public ViewResult OfferNewProduct() => View(new SellerProductsViewModel
        {
            Seller = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name),
            ProductRepository = _unitOfWork.Products
            
        });

        [HttpPost]
        public IActionResult OfferNewProduct(SellerProductsViewModel model)
        {
            
            InventoryItem item = new InventoryItem
            {           
                Seller = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name),
                Product = _unitOfWork.Products.Products.FirstOrDefault(x => x.Name == model.ProductName),
                StockQuantity = model.InventoryItem.StockQuantity,
                GoLive = false
            };
            _unitOfWork.InventoryItems.AddInventoryItem(item.Seller, item);
            return RedirectToAction(nameof(ProductsOffered));
        }
    }
}
