using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class CartController : Controller
    {
        private readonly IPricingService _pricingService;

        public CartController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        public IActionResult Checkout(decimal basePrice, string promoCode, decimal finalPrice)
        {

            ViewBag.BasePrice = basePrice;
            ViewBag.PromoCode = promoCode;
            ViewBag.FinalPrice = finalPrice;

            return View();
        }
    }
}
