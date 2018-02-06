using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Core;
using CooperativeEshop.Models.ViewModels;

namespace CooperativeEshop.Controllers
{
    public class SellerController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public SellerController(IUnitOfWork unit)
        {
            _unitOfWork = unit;            
        }

        public ViewResult ProductsOffered() => View(new SellerProductsViewModel {
            ProductRepository = _unitOfWork.Products,
            InventoryItemRepository = _unitOfWork.InventoryItems,
            PriceComponentRepository = _unitOfWork.PriceComponents
        });

        public ViewResult ProductNewOffer() => View(new SellerProductsViewModel {
            ProductRepository = _unitOfWork.Products,
            InventoryItemRepository = _unitOfWork.InventoryItems,
            PriceComponentRepository = _unitOfWork.PriceComponents
        });
    }
}
