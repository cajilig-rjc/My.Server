using Microsoft.EntityFrameworkCore;
using My.Data.Models;
using My.Data.Repository.Intefaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly MyDbContext _context;
        public PaymentRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Payment> GetAsync(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(int loanId, int? take = null, int? skip = null)
        {
           return   take != null && skip == null ? await _context.Payments.Where(x => x.LoanId == loanId).OrderByDescending(x => x.Date).Take((int)take).ToListAsync() :
                    take == null && skip != null ? await _context.Payments.Where(x => x.LoanId == loanId).OrderByDescending(x => x.Date).Skip((int)skip).ToListAsync() :
                    take != null && skip != null ? await _context.Payments.Where(x => x.LoanId == loanId).OrderByDescending(x => x.Date).Skip((int)skip).Take((int)take).ToListAsync() :
                    await _context.Payments.Where(x => x.LoanId == loanId).OrderByDescending(x => x.Date).ToListAsync();           
        }
    }
}
