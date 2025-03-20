using AkilliRandevuAPI.Models;

namespace AkilliRandevuAPI.Interfaces
{
    public interface IBusinessRepository : IGenericRepository<Business>
    {
        Task<IEnumerable<Business>> GetByBusinessTypeAsync(string businessType);
        Task<IEnumerable<Business>> SearchByNameAsync(string searchTerm);
        Task<IEnumerable<Service>> GetServicesAsync(string businessId);
        Task UpdateServicesAsync(string businessId, List<Service> services);
    }
} 