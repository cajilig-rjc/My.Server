using System.Threading.Tasks;

namespace My.Data.Repository.Intefaces
{
    public interface IMyDbRepository
    {

        Task<int> AddAsync<T>(T entity);
        Task<int> UpdateAsync<T>(T entity);
        Task<int> DeleteAsync<T>(T entity);
        IAccountRepository AccountRepository { get; }
        ILoanRepository LoanRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IUserRepository UserRepository { get; }

    }
}
