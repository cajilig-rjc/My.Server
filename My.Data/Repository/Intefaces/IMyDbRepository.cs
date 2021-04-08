using System.Threading.Tasks;

namespace My.Data.Repository.Intefaces
{
    public interface IMyDbRepository
    {

        Task AddAsync<T>(T entity);
        void Update<T>(T entity);
         void Delete<T>(T entity);
        Task<int> SaveChangesAsync();
        IAccountRepository AccountRepository { get; }
        ILoanRepository LoanRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IUserRepository UserRepository { get; }

    }
}
