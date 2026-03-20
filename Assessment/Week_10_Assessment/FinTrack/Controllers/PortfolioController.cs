using FinTrack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> assets = new List<Asset>()
        {
            new Asset { Id = 1, Name = "Apple", Value = 5000 },
            new Asset { Id = 2, Name = "Tesla", Value = 7000 },
            new Asset { Id = 3, Name = "Amazon", Value = 6500 }

        };
        // GET: PortfolioController
        public ActionResult Index()
        {
            double total = assets.Sum(a => a.Value);

            ViewData["Total"] = total;

            return View(assets);
        }

        // GET: PortfolioController/Details/5
        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

       

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: PortfolioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset != null)
            {
                assets.Remove(asset);
                TempData["Message"] = "Asset deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
