using Microsoft.AspNetCore.Mvc;
using CooperativeEshop.Models.ViewModels;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core;


namespace CooperativeEshop.Controllers
{
    public class AdminProductsController : Controller
    {
       
        private IUnitOfWork _unitOfWork;

        public AdminProductsController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
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
    }
}
