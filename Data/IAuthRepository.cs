using System.Threading.Tasks;
using databasePractice.Models;

namespace databasePractice.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
    }
}