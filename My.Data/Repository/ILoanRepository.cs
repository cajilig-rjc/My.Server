using My.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetLoansAsync(int accountId);
        Task<Loan> GetLoanAsync(int id);
        Task<int> AddLoanAsync(Loan loan);
        Task<int> UpdateLoanAsync(Loan loan);
        Task<int> DeleteLoanAsync(int id);
    }
}
