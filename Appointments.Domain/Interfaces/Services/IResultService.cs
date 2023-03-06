using Appointments.Domain.Entities;

namespace Appointments.Domain.Interfaces.Services
{
    public interface IResultService
    {
        Task<IEnumerable<Result?>> GetAllResults();
        Task<Result?> GetResult(int id);
        Task<bool> CreateResult(Result result);
        Task<bool> UpdateResult(int id, Result result);
        Task<bool> DeleteResult(int id);
    }
}
