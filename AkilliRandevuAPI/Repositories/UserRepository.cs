using AkilliRandevuAPI.Interfaces;
using AkilliRandevuAPI.Models;
using AkilliRandevuAPI.Settings;
using MongoDB.Driver;

namespace AkilliRandevuAPI.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MongoDbSettings settings) : base(settings)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetByUserTypeAsync(string userType)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserType, userType);
            return await _collection.Find(filter).ToListAsync();
        }
    }
} 