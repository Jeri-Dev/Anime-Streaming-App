using Application.Services;
using Application.ViewModels;
using Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace Streaming.Controllers
{
    public class GeneroController : Controller
    {

        public readonly GeneroService _service;

        public GeneroController(ApplicationContext _context)
        {
            _service = new( _context);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _service.GetAllGeneroViewModel());
        }

        public IActionResult AddView()
        {
            return View(new GeneroViewModel());
        }

        public async Task<IActionResult> AddAction(GeneroViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("AddView", model);
            }
            await _service.AddGeneroViewModel(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditView(int id)
        {
            var genero = await _service.GetByIdGeneroViewModel(id);
            return View(genero);
        }

        public async Task<IActionResult> EditAction(GeneroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditView", model);
            }

            await _service.EditGeneroViewModel(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteView(int id)
        {
            var genero = await _service.GetByIdGeneroViewModel(id);
            return View(genero);
        }

        public async Task<IActionResult> DeleteAction(int id)
        {
            await _service.RemoveGeneroViewModel(id);
            return RedirectToAction("Index");
        }

    }
}
