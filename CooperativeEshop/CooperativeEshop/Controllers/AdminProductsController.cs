using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Models.ViewModels;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using CooperativeEshop.Persistence.Repositories;

namespace CooperativeEshop.Controllers
{
    public class AdminProductsController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;
        private IUnitOfWork _unitOfWork;

        public AdminProductsController(IUnitOfWork unit, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _unitOfWork = unit;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public ViewResult AllProducts() => View(new ProductListViewModel {
            productRepository = _unitOfWork.Products
        });
        
        
        public IActionResult CreateProduct() => View();

        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel newProduct)
        {
            Product product = newProduct.Product;
            product.CoverFilePath = $"/Images/" + newProduct.Product.CoverFilePath;
            _unitOfWork.Products.AddProduct(product);
            return RedirectToAction(nameof(CreateProduct));
        }

        [HttpPost]
        public IActionResult DeleteProduct(int ProductID)
        {
            _unitOfWork.Products.DeleteProduct(ProductID);
            return RedirectToAction(nameof(AllProducts));
        }
        //[HttpPost]
        //public IActionResult GoLive(InventoryItem item)
        //{
        //    item.GoLive = true;
        //    _unitOfWork.InventoryItems.UpdateInventoryItem(item);
        //    return RedirectToAction(nameof(PendingProducts));
        //}

        public async Task<IActionResult> PendingProducts()
        {
            var users = _userManager.Users;
            List<AppUser> AllSellers = new List<AppUser>();
            foreach (AppUser user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Seller"))
                {
                    AllSellers.Add(user);
                }
            }
            
            AdminPendingProductsViewModel pendingProducts = new AdminPendingProductsViewModel
            {
                Sellers = AllSellers,
                PendingInventoryItems = _unitOfWork.InventoryItems.InventoryItems.Where(x => x.GoLive == false),
                PriceComponentRepository = _unitOfWork.PriceComponents
            };
            return View(pendingProducts);           
        }
        [HttpPost]
        public IActionResult GoLive(AdminPendingProductsViewModel model)
        {
            InventoryItem item = _unitOfWork.InventoryItems.InventoryItems.FirstOrDefault(x => x.InventoryItemID == model.InventoryItemID);
            item.GoLive = true;
            ProductPriceComponents component = _unitOfWork.PriceComponents.PriceComponents
                .FirstOrDefault(x => x.InventoryItemID == item.InventoryItemID);
            component.SalePrice = model.SalePrice;
            
            _unitOfWork.InventoryItems.UpdateInventoryItem(item);
            _unitOfWork.PriceComponents.UpdatePriceComponent(component);

            return RedirectToAction(nameof(PendingProducts));
        }
    }
}
