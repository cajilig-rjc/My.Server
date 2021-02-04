using Microsoft.EntityFrameworkCore;
using My.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class MyDbRepository:IAccountRepository,ILoanRepository,IPaymentRepository,IUserRepository
    {
        private readonly MyDbContext _context;
        public MyDbRepository(MyDbContext context)
        {
            _context = context;
        }       
        #region Account CRUD
        public async Task<int> DeleteAccountAsync(int id)
        {
            // Delete or transfer to archive table or add deleted flag.
            _context.Accounts.Remove(await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id));
            return await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccountAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<int> AddAccountAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAccountAsync(Account account)
        {            
            _context.Accounts.Update(account);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Loan CRUD
        public async Task<IEnumerable<Loan>> GetLoansAsync(int accountId)
        {
            var loans =await _context.Loans.ToListAsync();
            var payments = await _context.Payments.ToListAsync();
            // You can execute raw query here or just simply LINQ depends on situation
            return  (from loan in loans
                          select new Loan
                          {
                              Id = loan.Id,
                              AccountId = loan.AccountId,
                              Date = loan.Date,
                              Amount = loan.Amount,
                              Balance = loan.Amount - payments.Where(x => x.LoanId == loan.Id).Sum(x => x.Amount), // Calculate Balance
                              IsClosed = loan.IsClosed,
                              Status = loan.Status,
                              Payments = payments.Where(x => x.LoanId == loan.Id).OrderByDescending(x => x.Date).ToList() // List Payments
                          }).Where(x=>x.AccountId == accountId).ToList();
        }

        public async Task<Loan> GetLoanAsync(int id)
        {
            var loans = await _context.Loans.Where(x=>x.Id == id).ToListAsync();
            var payments = await _context.Payments.Where(x=>x.LoanId == id).ToListAsync();
            return (from loan in loans
                    select new Loan
                    {
                        Id = loan.Id,
                        AccountId = loan.AccountId,
                        Date = loan.Date,
                        Amount = loan.Amount,
                        Balance = loan.Amount - payments.Where(x => x.LoanId == loan.Id).Sum(x => x.Amount), // Calculate Balance
                        IsClosed = loan.IsClosed,
                        Status = loan.Status,
                        Payments = payments.Where(x => x.LoanId == loan.Id).OrderByDescending(x => x.Date).ToList() // List Payments
                    }).FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> AddLoanAsync(Loan loan)
        {
           await _context.Loans.AddAsync(loan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateLoanAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteLoanAsync(int id)
        {
            // Delete or transfer to archive table or add deleted flag.
            _context.Loans.Remove(await _context.Loans.FirstOrDefaultAsync(x => x.Id == id));
            return await _context.SaveChangesAsync();
        }

        #endregion
        #region Payment CRUD
        public async Task<IEnumerable<Payment>> GetPaymentsAsync(int loanId)
        {
            return await _context.Payments.Where(x => x.LoanId == loanId).OrderByDescending(x=>x.Date).ToListAsync();
        }

        public async Task<Payment> GetPaymentAsync(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePaymentAsync(int id)
        {
            // Delete or transfer to archive table or add deleted flag.
            _context.Payments.Remove(await _context.Payments.FirstOrDefaultAsync(x => x.Id == id));
            return await _context.SaveChangesAsync();
        }
        #endregion      
        //User
        public async Task<User> GetUserAsync(string userName, string password)
        {
           return await _context.Users.SingleOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower() && x.Password == password);
        }
    }
}
