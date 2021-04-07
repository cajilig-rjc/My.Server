using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class MyDbGenericRepository<T> where T: class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;
        public MyDbGenericRepository(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>>GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<int> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
