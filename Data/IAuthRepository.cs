using System.Threading.Tasks;
using databasePractice.Models;

namespace databasePractice.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);

        Task<bool> IsUserExist(string email);

        Task<User> Login(string email, string password);

        string GetTokenString(User user);
    }
}