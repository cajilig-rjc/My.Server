using My.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository.Intefaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync(int? take = null , int? skip = null);
        Task<Account> GetAsync(int id);       
    }
}
