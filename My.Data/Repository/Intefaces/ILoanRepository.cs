using My.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository.Intefaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync(int accountId, int? take = null, int? skip = null);
        Task<Loan> GetAsync(int id);       
    }
}
