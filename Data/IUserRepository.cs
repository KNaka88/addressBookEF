using System.Collections.Generic;
using System.Threading.Tasks;
using databasePractice.Models;

namespace databasePractice.Data
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> IsSaved();
    }
}