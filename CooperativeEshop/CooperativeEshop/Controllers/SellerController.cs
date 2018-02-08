using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Core;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using CooperativeEshop.Core.Repositories;
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

        public IActionResult ProductsOffered()
        {
            AppUser seller = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            IInventoryItemRepository inventoryItemRepository = _unitOfWork.InventoryItems;
            IPriceComponentRepository priceComponentRepository = _unitOfWork.PriceComponents;
            SellerProductsOfferedViewModel model = new SellerProductsOfferedViewModel
            {
                Seller = seller,
                SellerRepository = inventoryItemRepository.GetSellerItems(seller),
                InventoryItemRepository = inventoryItemRepository,
                PriceComponentRepository = priceComponentRepository
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

            ProductPriceComponents components = new ProductPriceComponents
            {
                InventoryItem = item,
                FromDate = DateTime.Today,
                BasePrice = model.BasePrice
            };

            _unitOfWork.InventoryItems.AddInventoryItem(item.Seller, item);
            _unitOfWork.PriceComponents.AddPriceComponent(components);
            return RedirectToAction(nameof(ProductsOffered));
        }

        [HttpPost]
        public IActionResult DeleteInventoryItem(int IneventoryItemID)
        {
            _unitOfWork.InventoryItems.DeleteInventoryItem(IneventoryItemID);
            return RedirectToAction(nameof(ProductsOffered));
        }

        public IActionResult ViewBasePrices()
        {
            AppUser seller = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            IInventoryItemRepository inventoryItemRepository = _unitOfWork.InventoryItems;
            IPriceComponentRepository PriceComponentRepository = _unitOfWork.PriceComponents;

            SellerBasePricesViewModel model = new SellerBasePricesViewModel
            {
                Seller = seller,
                SellerRepository = inventoryItemRepository.GetSellerItems(seller),
                InventoryItemRepository = inventoryItemRepository,
                PriceComponentRepository = PriceComponentRepository
            };
            return View(model);
        }

        //[HttpPost]
        //public IActionResult ViewBasePrices()
        //{

        //}
    }
}
