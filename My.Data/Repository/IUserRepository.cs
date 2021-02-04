using My.Data.Models;
using System.Threading.Tasks;

namespace My.Data.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userName, string password);      

    }
}
