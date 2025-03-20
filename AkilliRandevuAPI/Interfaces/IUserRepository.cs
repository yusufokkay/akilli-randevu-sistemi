using AkilliRandevuAPI.Models;

namespace AkilliRandevuAPI.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetByUserTypeAsync(string userType);
    }
} 