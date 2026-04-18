using Microsoft.AspNetCore.Mvc;
using NorthWindCatalog.Services.DTOs;

namespace NorthWindCatalog.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IHttpClientFactory _factory;

        public SummaryController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _factory.CreateClient("api");

            var data = await client.GetFromJsonAsync<List<CategorySummaryDto>>("api/products/summary");

            return View(data);
        }
    }
}
