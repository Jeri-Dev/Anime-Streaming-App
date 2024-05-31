using Application.Repositories;
using Application.ViewModels;
using Database.Context;
using Database.Entities;

namespace Application.Services
{
    public class ProductoraService
    {
        private readonly ProductoraRepository _repository;

        public ProductoraService(ApplicationContext context)
        {
            _repository = new(context);
        }

        public async Task<ICollection<ProductoraViewModel>> GetAllProductoraViewModel()
        {
            var productoraList = await _repository.GetAllProductoras();
            return productoraList.Select(p => new ProductoraViewModel { Name = p.Name, Id = p.Id }).ToList();
        }

        public async Task AddProductoraViewModel(ProductoraViewModel model)
        {
            Productora pr = new()
            {
                Name = model.Name
            };

            await _repository.AddAsyncProductora(pr);
            model.Id = pr.Id;
        }

        public async Task RemoveProductoraViewModel(int id)
        {
            var pr = await _repository.GetProductoraById(id);
            await _repository.RemoveAsyncGenero(pr);
        }

        public async Task EditProductoraViewModel(ProductoraViewModel model)
        {
            Productora pr = new()
            {
                Id = model.Id,
                Name = model.Name
            };

            await _repository.EditAsyncProductora(pr);

        }

        public async Task<ProductoraViewModel> GetByIdProductoraViewModel(int id)
        {
            var genero = await _repository.GetProductoraById(id);

            ProductoraViewModel editpr = new ProductoraViewModel()
            {
                Id = genero.Id,
                Name = genero.Name
            };

            return editpr;
        }
    }
}
