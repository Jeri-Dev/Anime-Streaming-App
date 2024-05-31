using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class ProductoraRepository
    {
        private readonly ApplicationContext _context;

        public ProductoraRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Productora>> GetAllProductoras()
        {
            return await _context.Productora.ToListAsync();
        }

        //Retornar un solo elemento por ID
        public async Task<Productora> GetProductoraById(int id)
        {
            return await _context.Set<Productora>().FindAsync(id);
        }

        //Add nuevo elemento
        public async Task AddAsyncProductora(Productora pr)
        {
            await _context.Productora.AddAsync(pr);
            await _context.SaveChangesAsync();
        }


        //Editar un elemento
        public async Task EditAsyncProductora(Productora pr)
        {
            _context.Entry(pr).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Remover un elemento
        public async Task RemoveAsyncGenero(Productora pr)
        {
            _context.Set<Productora>().Remove(pr);
            await _context.SaveChangesAsync();
        }
    }
}
