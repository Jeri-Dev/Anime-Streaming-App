using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class SerieRepository
    {


        private readonly ApplicationContext _context;

        public SerieRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Serie>> GetAllSeries()
        {
            return await _context.Serie
            .Include(s => s.Genero)
            .Include(s => s.Productora)
            .ToListAsync();
        }


        //Retornar un solo elemento por ID
        public async Task<Serie> GetSerieById(int id)
        {
            return await _context.Set<Serie>().FindAsync(id);
        }

        //Add nuevo elemento
        public async Task AddAsyncSerie(Serie serie)
        {
            await _context.Serie.AddAsync(serie);
            await _context.SaveChangesAsync();
        }


        //Editar un elemento
        public async Task EditAsyncSerie(Serie serie)
        {
            _context.Entry(serie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Remover un elemento
        public async Task RemoveAsyncSerie(Serie serie)
        {
            _context.Set<Serie>().Remove(serie);
            await _context.SaveChangesAsync();
        }
    }
}

