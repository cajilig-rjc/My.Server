using My.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(int id);
        Task<int> AddAccountAsync(Account account);
        Task<int> UpdateAccountAsync(Account account);
        Task<int> DeleteAccountAsync(int id);
    }
}
