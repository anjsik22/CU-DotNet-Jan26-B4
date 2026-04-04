using Microsoft.AspNetCore.Mvc;
using Travel.FrontEnd.Models;
using Travel.FrontEnd.Services;

namespace Travel.FrontEnd.Controllers
{
    public class TravelController : Controller
    {
        private readonly IDestinationService _service;

        public TravelController(IDestinationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Destination model)
        {
            await _service.CreateAsync(model);
            return RedirectToAction("Index");
        }

        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetAllAsync();
            var item = data.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Destination model)
        {
            await _service.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
