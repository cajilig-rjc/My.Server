using My.Data.Models;
using System.Threading.Tasks;

namespace My.Data.Repository.Intefaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string userName, string password);      

    }
}
