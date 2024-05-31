using Application.Repositories;
using Application.Services;
using Application.ViewModels;
using Database.Context;
using Microsoft.AspNetCore.Mvc;


namespace Streaming.Controllers
{
    public class SerieController : Controller
    {
        public readonly SerieService _service;

        public ApplicationContext _context;

        public readonly GeneroRepository _grepository;
        public readonly ProductoraRepository _prepository;
        public SerieController(ApplicationContext context)
        {
            _context = context;
            _service = new(context);
            _grepository = new(context);
            _prepository = new(context);

        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllSeriesViewModel());
        }

        public async Task<IActionResult> AddView()
        {
            var generos = await _grepository.GetAllGeneros();
            var productoras = await _prepository.GetAllProductoras();
            ViewBag.Generos = generos.Select(g => new GeneroViewModel { Name = g.Name,  Id = g.Id }).ToList();
            ViewBag.Productoras = productoras.Select(p => new ProductoraViewModel { Name = p.Name, Id = p.Id }).ToList();

            return View(new SerieViewModel());
        }

        public async Task<IActionResult> AddAction(SerieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var generos = await _grepository.GetAllGeneros();
                var productoras = await _prepository.GetAllProductoras();

                ViewBag.Generos = generos.Select(g => new GeneroViewModel { Name = g.Name, Id = g.Id }).ToList();
                ViewBag.Productoras = productoras.Select(p => new ProductoraViewModel { Name = p.Name, Id = p.Id }).ToList();
                return View("AddView", model);
            }

            await _service.AddSerieViewModel(model);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditView(int id) {
            var generos = await _grepository.GetAllGeneros();
            var productoras = await _prepository.GetAllProductoras();

            ViewBag.Generos = generos.Select(g => new GeneroViewModel { Name = g.Name, Id = g.Id }).ToList();
            ViewBag.Productoras = productoras.Select(p => new ProductoraViewModel { Name = p.Name, Id = p.Id }).ToList();

            var serie = await _service.GetByIdSerieViewModel(id);
            return View(serie);
        }

        public async Task<ActionResult> EditAction(SerieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Generos = (await _grepository.GetAllGeneros()).Select(g => new GeneroViewModel { Name = g.Name, Id = g.Id }).ToList();
                ViewBag.Productoras = (await _prepository.GetAllProductoras()).Select(p => new ProductoraViewModel { Name = p.Name, Id = p.Id }).ToList();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View("EditView", model);
            }
            await _service.Edit(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteView(int id)
        {
            var serie = await _service.GetByIdSerieViewModel(id);
            return View(serie);
        }

        public async Task<IActionResult> DeleteAction(int id)
        {
            await _service.RemoveSerieViewModel(id);
            return RedirectToAction("Index");
        }



    }
}
