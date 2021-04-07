using Microsoft.EntityFrameworkCore;
using My.Data.Models;
using My.Data.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly MyDbContext _context;
        public LoanRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Loan> GetAsync(int id)
        {
            return await _context.Loans.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<Loan>> GetAllAsync(int accountId, int? take = null, int? skip = null)
        {
            var loans = 
                    take != null && skip == null ? await _context.Loans.Where(x => x.AccountId == accountId).Take((int)take).ToListAsync() :
                    take == null && skip != null ? await _context.Loans.Where(x => x.AccountId == accountId).Skip((int)skip).ToListAsync() :
                    take != null && skip != null ? await _context.Loans.Where(x => x.AccountId == accountId).Skip((int)skip).Take((int)take).ToListAsync() :
                    await _context.Loans.Where(x => x.AccountId == accountId).ToListAsync();

            var payments = await _context.Payments.ToListAsync();          
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
                    }).ToList();
        }
    }
}
