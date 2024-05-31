using Application.Repositories;
using Application.Services;
using Application.ViewModels;
using Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace Streaming.Controllers
{
    public class HomeController : Controller
    {

        public readonly SerieService _service;
        public readonly ApplicationContext context;

        public readonly GeneroRepository _grepository;
        public readonly ProductoraRepository _prepository;

        public HomeController(ApplicationContext _context)
        {
            _service = new(_context);
            _grepository = new(_context);
            _prepository = new(_context);
            context = _context;
        }

        public async Task<List<object>> GetLists()
        {
            var generos = await _grepository.GetAllGeneros();
            var vbgeneros = generos.Select(g => new GeneroViewModel { Name = g.Name!, Id = g.Id }).ToList();
            var productoras = await _prepository.GetAllProductoras();
            var vbproductoras = productoras.Select(p => new ProductoraViewModel { Name = p.Name!, Id = p.Id }).ToList();

            return [vbgeneros, vbproductoras];
        }

        public async Task<IActionResult> Index()
        {


            ViewBag.Generos = GetLists().Result[0];
            ViewBag.Productoras = GetLists().Result[1];

            return View(await _service.GetAllSeriesViewModel());
        }

        public async Task<IActionResult> ViewEpisode(int id) { 

            var serie = await _service.GetByIdSerieViewModel(id);
            return View(serie);
        }


        public IActionResult Search(string input)
        {

            ViewBag.Generos = GetLists().Result[0];
            ViewBag.Productoras = GetLists().Result[1];

            var s = from serie in context.Serie select serie;

            var searched = s.Select(s => new SerieViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImagePath = s.ImagePath,
                VideoPath = s.VideoPath,
                GeneroId = s.GeneroId,
                GeneroName = s.Genero.Name,
                ProductoraId = s.ProductoraId,
                ProductoraName = s.Productora!.Name
            }).Where(s => s.Name!.Contains(input)).ToList();

            if (!string.IsNullOrEmpty(input))
            {
                return View("Index", searched);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult OrderBy(int option)
        {
            ViewBag.Generos = GetLists().Result[0];
            ViewBag.Productoras = GetLists().Result[1];

            var s = from serie in context.Serie select serie;

            var searched = s.Select(s => new SerieViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImagePath = s.ImagePath,
                VideoPath = s.VideoPath,
                GeneroId = s.GeneroId,
                GeneroName = s.Genero.Name,
                ProductoraId = s.ProductoraId,
                ProductoraName = s.Productora!.Name
            });

            List<SerieViewModel> a = option == 1 ? [.. searched.OrderBy(s => s.Name)] : [.. searched.OrderByDescending(s => s.Name)];


            return View("Index", a);
        }

        public IActionResult Filter(List<int> SelectedProductorasIds, List<int> SelectedGenerosIds)
        {
            ViewBag.Generos = GetLists().Result[0];
            ViewBag.Productoras = GetLists().Result[1];

            var s = from serie in context.Serie select serie;
            List<SerieViewModel> fgeneros = [];

            var filteredAnimes = s.Select(s => new SerieViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImagePath = s.ImagePath,
                VideoPath = s.VideoPath,
                GeneroId = s.GeneroId,
                GeneroName = s.Genero.Name,
                ProductoraId = s.ProductoraId,
                ProductoraName = s.Productora!.Name
            }).ToList();

            fgeneros = filteredAnimes;

            if (SelectedProductorasIds.Count > 0)
            {
                fgeneros = filteredAnimes.Where(s => SelectedProductorasIds.Contains(s.ProductoraId)).ToList();
            }

            if (SelectedGenerosIds.Count > 0)
            {
                fgeneros = filteredAnimes.Where(s => SelectedGenerosIds.Contains(s.GeneroId)).ToList();

            }
                if (SelectedGenerosIds.Count > 0 && SelectedProductorasIds.Count > 0)
                {
                    fgeneros = filteredAnimes.Where(s => SelectedGenerosIds.Contains(s.GeneroId)).Where(s => SelectedProductorasIds.Contains(s.ProductoraId)).ToList();
                }

                ViewBag.SelectedP = fgeneros.Select(s => s.Id).ToList();

            return View("Index", fgeneros);
        }
    }
}
