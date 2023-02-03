using Appointments.Domain.Entities;

namespace Profiles.Domain.Interfaces.Services
{
    public interface IResultService
    {
        Task<IEnumerable<Result?>> GetAllResults();
        Task<Result?> GetResult(int id);
        Task<Result?> CreateResult(Result result);
        Task<Result?> UpdateResult(Result result);
        Task<Result?> DeleteResult(int id);
    }
}
