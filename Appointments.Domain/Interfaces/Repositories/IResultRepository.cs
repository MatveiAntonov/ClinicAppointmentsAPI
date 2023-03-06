using Appointments.Domain.Entities;

namespace Appointments.Domain.Interfaces.Repositories
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result?>> GetAllResults();
        Task<Result?> GetResult(int id);
        Task<bool> CreateResult(Result result);
        bool UpdateResult(Result result, Result entity);
        bool DeleteResult(Result result);
    }
}
