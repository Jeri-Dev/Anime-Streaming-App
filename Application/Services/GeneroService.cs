using Application.Repositories;
using Application.ViewModels;
using Database.Context;
using Database.Entities;

namespace Application.Services
{
    public class GeneroService
    {
        private readonly GeneroRepository _repository;

        public GeneroService(ApplicationContext context)
        {
            _repository = new(context);
        }

        public async Task<ICollection<GeneroViewModel>> GetAllGeneroViewModel()
        {
            var generoList = await _repository.GetAllGeneros();
            return generoList.Select(p => new GeneroViewModel { Name = p.Name, Id = p.Id }).ToList();
        }

        public async Task AddGeneroViewModel(GeneroViewModel model)
        {
            Genero genero = new()
            {
                Name = model.Name
            };

            await _repository.AddAsyncGenero(genero);

            model.Id = genero.Id;
        }

        public async Task RemoveGeneroViewModel(int id)
        {
            var genero = await _repository.GetGeneroById(id);
            await _repository.RemoveAsyncGenero(genero);
        }

        public async Task EditGeneroViewModel(GeneroViewModel model)
        {
            Genero genero = new()
            {
                Id = model.Id,
                Name = model.Name

            };

            await _repository.EditAsynnGenero(genero);

        }

        public async Task<GeneroViewModel> GetByIdGeneroViewModel(int id)
        {
            var genero = await _repository.GetGeneroById(id);

            GeneroViewModel editgenero = new GeneroViewModel()
            {
                Id = genero.Id,
                Name = genero.Name
            };

            return editgenero;
        }
    }
}
