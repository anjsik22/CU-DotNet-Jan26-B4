using Microsoft.AspNetCore.Mvc;

namespace FinTrack.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Summary()
        {
            ViewBag.MarketStatus = "Open";

            ViewData["TopGainer"] = "NVIDIA";

            ViewData["Volume"] = 12500000L;

            return View();
        }

        // Task A: Routing Challenge
        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Analyze(string ticker, int? days)
        {
            int analysisDays = days ?? 30;

            ViewBag.Ticker = ticker;
            ViewBag.Days = analysisDays;

            return View();
        }
    }
}
