using AkilliRandevuAPI.Interfaces;
using AkilliRandevuAPI.Models;
using AkilliRandevuAPI.Settings;
using MongoDB.Driver;

namespace AkilliRandevuAPI.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(MongoDbSettings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Appointment>> GetByCustomerIdAsync(string customerId)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.CustomerId, customerId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByBusinessIdAsync(string businessId)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.BusinessId, businessId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var filter = Builders<Appointment>.Filter.And(
                Builders<Appointment>.Filter.Gte(a => a.AppointmentDateTime, startDate),
                Builders<Appointment>.Filter.Lte(a => a.AppointmentDateTime, endDate)
            );
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByStatusAsync(string status)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.Status, status);
            return await _collection.Find(filter).ToListAsync();
        }
    }
} 