using My.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync(int loanId);
        Task<Payment> GetPaymentAsync(int id);
        Task<int> AddPaymentAsync(Payment payment);
        Task<int> UpdatePaymentAsync(Payment payment);
        Task<int> DeletePaymentAsync(int id);
    }
}
