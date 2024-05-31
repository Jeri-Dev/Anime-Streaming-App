using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class GeneroRepository
    {
        private readonly ApplicationContext _context;

        public GeneroRepository(ApplicationContext context)
        {
            _context = context;
        }


        //Retornar todos los elementos
        public async Task<List<Genero>> GetAllGeneros()
        {
            return await _context.Genero.ToListAsync();
        }

        //Retornar un solo elemento por ID
        public async Task<Genero> GetGeneroById(int id)
        {
            return await _context.Set<Genero>().FindAsync(id);
        }

        //Add nuevo elemento
        public async Task AddAsyncGenero(Genero genero)
        {
            await _context.Genero.AddAsync(genero);
            await _context.SaveChangesAsync();
        }

        //Editar un elemento
        public async Task EditAsynnGenero(Genero genero)
        {
            _context.Entry(genero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Remover un elemento
        public async Task RemoveAsyncGenero(Genero genero)
        {
            _context.Set<Genero>().Remove(genero);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Genero>> GetByNamesAsync(ICollection<string> names)
        {
            return await _context.Genero.Where(g => names.Contains(g.Name)).ToListAsync();
        }
    }
}
