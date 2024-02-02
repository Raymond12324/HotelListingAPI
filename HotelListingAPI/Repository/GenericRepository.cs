using HotelListingAPI.Contracts;
using HotelListingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListListingDbContext _context;
        public GenericRepository(HotelListListingDbContext context)
        {
            this._context = context;    
        }
        public async Task<T> AddAsync(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entitie = await GetAsync(id);
            _context.Set<T>().Remove(entitie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entitie = await GetAsync(id);
            return entitie != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
           
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;            
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
