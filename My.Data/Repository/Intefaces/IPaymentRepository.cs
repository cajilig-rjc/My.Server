using My.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository.Intefaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync(int loanId, int? take = null, int? skip = null);
        Task<Payment> GetAsync(int id);      
    }
}
