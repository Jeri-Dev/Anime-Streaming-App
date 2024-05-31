using Application.Repositories;
using Application.ViewModels;
using Database.Context;
using Database.Entities;

namespace Application.Services
{
    public class SerieService
    {

        private readonly SerieRepository _repository;
        //private readonly GeneroRepository _grepository;


        public SerieService(ApplicationContext context)
        {
            _repository = new(context);
            //_grepository = new(context);
        }

        public async Task<ICollection<SerieViewModel>> GetAllSeriesViewModel()
        {
            var seriesList = await _repository.GetAllSeries();

            return seriesList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImagePath = serie.ImagePath,
                VideoPath = serie.VideoPath,
                ProductoraId = serie.ProductoraId,
                ProductoraName = serie.Productora.Name,
                GeneroId = serie.GeneroId,
                GeneroName = serie.Genero.Name

            }).ToList();
        }


        public async Task AddSerieViewModel(SerieViewModel model)
        {
            Serie serie = new()
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                VideoPath = model.VideoPath,
                ProductoraId = model.ProductoraId,
                GeneroId = model.GeneroId
            };
           
            await _repository.AddAsyncSerie(serie);

        }

        public async Task RemoveSerieViewModel(int id)
        {
            var genero = await _repository.GetSerieById(id);
            await _repository.RemoveAsyncSerie(genero);
        }

        public async Task Edit(SerieViewModel svm)
        {
            Serie serie = new()
            {
                ImagePath = svm.ImagePath,
                VideoPath = svm.VideoPath,
                ProductoraId = svm.ProductoraId,
                Name = svm.Name,
                GeneroId = svm.GeneroId,
                Id = svm.Id
                
            };

            await _repository.EditAsyncSerie(serie);
        }

        public async Task<SerieViewModel> GetByIdSerieViewModel(int id)
        {


            var serie = await _repository.GetSerieById(id);
            if (serie == null)
            {
                throw new Exception("Serie not found");
            }


            var model = new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImagePath = serie.ImagePath,
                VideoPath = serie.VideoPath,
                ProductoraId = serie.ProductoraId,
                GeneroId = serie.GeneroId
            };

            if (model == null)
            {
                throw new Exception("Model not created");
            }

            return model;
        }

    }
}
