using AkilliRandevuAPI.Models;

namespace AkilliRandevuAPI.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetByCustomerIdAsync(string customerId);
        Task<IEnumerable<Appointment>> GetByBusinessIdAsync(string businessId);
        Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Appointment>> GetByStatusAsync(string status);
    }
} 