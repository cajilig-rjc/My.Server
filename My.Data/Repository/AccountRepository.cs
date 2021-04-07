using Microsoft.EntityFrameworkCore;
using My.Data.Models;
using My.Data.Repository.Intefaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly MyDbContext _context;
        public AccountRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync(int? take = null, int? skip = null)
        {

            return  take != null && skip == null ? await _context.Accounts.Take((int)take).ToListAsync() :
                    take == null && skip != null ? await _context.Accounts.Skip((int)skip).ToListAsync() :
                    take != null && skip != null ? await _context.Accounts.Skip((int)skip).Take((int)take).ToListAsync() :
                    await _context.Accounts.ToListAsync();
                   
        }

        public async Task<Account> GetAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
