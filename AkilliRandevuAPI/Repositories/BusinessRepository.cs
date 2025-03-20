using AkilliRandevuAPI.Interfaces;
using AkilliRandevuAPI.Models;
using AkilliRandevuAPI.Settings;
using MongoDB.Driver;

namespace AkilliRandevuAPI.Repositories
{
    public class BusinessRepository : GenericRepository<Business>, IBusinessRepository
    {
        public BusinessRepository(MongoDbSettings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Business>> GetByBusinessTypeAsync(string businessType)
        {
            var filter = Builders<Business>.Filter.Eq(b => b.BusinessType, businessType);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Business>> SearchByNameAsync(string searchTerm)
        {
            var filter = Builders<Business>.Filter.Regex(b => b.Name, 
                new MongoDB.Bson.BsonRegularExpression(searchTerm, "i"));
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetServicesAsync(string businessId)
        {
            var filter = Builders<Business>.Filter.Eq("Id", businessId);
            var business = await _collection.Find(filter).FirstOrDefaultAsync();
            return business?.Services ?? new List<Service>();
        }

        public async Task UpdateServicesAsync(string businessId, List<Service> services)
        {
            var filter = Builders<Business>.Filter.Eq("Id", businessId);
            var update = Builders<Business>.Update.Set(b => b.Services, services);
            await _collection.UpdateOneAsync(filter, update);
        }
    }
} 