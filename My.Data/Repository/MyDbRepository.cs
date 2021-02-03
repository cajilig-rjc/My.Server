using Microsoft.EntityFrameworkCore;
using My.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class MyDbRepository:IDisposable,IAccountRepository,ILoanRepository,IPaymentRepository
    {
        private readonly MyDbContext _context;
        public MyDbRepository(MyDbContext context)
        {
            _context = context;
        }       
        #region Account CRUD
        public async Task<int> DeleteAccountAsync(int id)
        {
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
            _context.Accounts.Add(account);
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
            return await (from loan in _context.Loans
                          orderby loan.Date
                          select new Loan
                          {
                              Id = loan.Id,
                              AccountId = loan.AccountId,
                              Date = loan.Date,
                              Amount = loan.Amount,
                              Balance = loan.Amount - _context.Payments.Where(x => x.LoanId == loan.Id).Sum(x => x.Amount), // Calculate Balance
                              IsClosed = loan.IsClosed,
                              Status = loan.Status,
                              Payments = _context.Payments.Where(x => x.LoanId == loan.Id).OrderBy(x => x.Date).ToList() // List Payments
                          }).ToListAsync();
        }

        public async Task<Loan> GetLoanAsync(int id)
        {
            return await (from loan in _context.Loans
                          select new Loan
                          {
                              Id = loan.Id,
                              AccountId = loan.AccountId,
                              Date = loan.Date,
                              Amount = loan.Amount,
                              Balance = loan.Amount - _context.Payments.Where(x => x.LoanId == loan.Id).Sum(x => x.Amount),
                              IsClosed = loan.IsClosed,
                              Status = loan.Status,
                              Payments = _context.Payments.Where(x => x.LoanId == loan.Id).OrderBy(x=>x.Date).ToList()
                          }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddLoanAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateLoanAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteLoanAsync(int id)
        {
            _context.Loans.Remove(await _context.Loans.FirstOrDefaultAsync(x => x.Id == id));
            return await _context.SaveChangesAsync();
        }

        #endregion
        #region Payment CRUD
        public async Task<IEnumerable<Payment>> GetPaymentsAsync(int loanId)
        {
            return await _context.Payments.Where(x => x.LoanId == loanId).OrderBy(x=>x.Date).ToListAsync();
        }

        public async Task<Payment> GetPaymentAsync(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddPaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePaymentAsync(int id)
        {
            _context.Payments.Remove(await _context.Payments.FirstOrDefaultAsync(x => x.Id == id));
            return await _context.SaveChangesAsync();
        }
        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
