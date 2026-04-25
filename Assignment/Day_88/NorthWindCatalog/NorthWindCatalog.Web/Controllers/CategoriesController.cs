using Microsoft.AspNetCore.Mvc;
using NorthWindCatalog.Services.DTOs;

namespace NorthWindCatalog.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IHttpClientFactory _factory;

        public CategoriesController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _factory.CreateClient("api");

            var data = await client.GetFromJsonAsync<List<CategoryDto>>("api/categories");

            return View(data);
        }
    }
}
