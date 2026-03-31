using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IPricingService _pricingService;

        public ProductsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Index(decimal basePrice, string promoCode)
        {
            decimal finalPrice = _pricingService.CalculatePrice(basePrice, promoCode);

            return RedirectToAction("Checkout", "Cart", new
            {
                basePrice = basePrice,
                promoCode = promoCode,
                finalPrice = finalPrice
            });
        }
    }
}
