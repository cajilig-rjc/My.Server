using Microsoft.EntityFrameworkCore;
using My.Data.Repository.Intefaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class MyDbGenericRepository<T>:IGenericRepository<T> where T : class
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
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);           
        }
        public void Update(T entity)
        {
            _context.Update(entity);           
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);           
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
      
    }
}
