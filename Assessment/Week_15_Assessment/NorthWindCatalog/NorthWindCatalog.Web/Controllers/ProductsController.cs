using Microsoft.AspNetCore.Mvc;
using NorthWindCatalog.Services.DTOs;

namespace NorthWindCatalog.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _factory;

        public ProductsController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IActionResult> ByCategory(int id)
        {
            var client = _factory.CreateClient("api");

            var data = await client.GetFromJsonAsync<List<ProductDto>>($"api/products/by-category/{id}");

            return View(data);
        }
    }
}
