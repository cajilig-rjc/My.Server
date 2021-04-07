using My.Data.Repository.Intefaces;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class MyDbRepository : IMyDbRepository
    {
        private readonly MyDbContext _context;
        public MyDbRepository(MyDbContext context)
        {
            _context = context;
        }
        public IAccountRepository AccountRepository => new AccountRepository(_context);

        public ILoanRepository LoanRepository => new LoanRepository(_context);

        public IPaymentRepository PaymentRepository => new PaymentRepository(_context);

        public IUserRepository UserRepository => throw new System.NotImplementedException();

        public async Task<int> AddAsync<T>(T entity)
        {
           await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<T>(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync<T>(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();
           
        }
    }
}
