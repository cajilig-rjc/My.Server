using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository.Intefaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(object id);
    }
}
