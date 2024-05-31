using Application.Services;
using Application.ViewModels;
using Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace Streaming.Controllers
{
    public class ProductoraController : Controller
    {

        public readonly ProductoraService _service;

        public ProductoraController(ApplicationContext _context)
        {
            _service = new(_context);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _service.GetAllProductoraViewModel());
        }

        public IActionResult AddView()
        {
            return View(new ProductoraViewModel());
        }

        public async Task<IActionResult> AddAction(ProductoraViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("AddView", model);
            }
            await _service.AddProductoraViewModel(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditView(int id)
        {
            var genero = await _service.GetByIdProductoraViewModel(id);
            return View(genero);
        }

        public async Task<IActionResult> EditAction(ProductoraViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditView", model);
            }

            await _service.EditProductoraViewModel(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteView(int id)
        {
            var genero = await _service.GetByIdProductoraViewModel(id);
            return View(genero);
        }

        public async Task<IActionResult> DeleteAction(int id)
        {
            await _service.RemoveProductoraViewModel(id);
            return RedirectToAction("Index");
        }
    }
}
