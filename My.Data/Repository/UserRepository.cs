using Microsoft.EntityFrameworkCore;
using My.Data.Models;
using My.Data.Repository.Intefaces;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(string userName, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower() && x.Password == password);
        }
    }
}
