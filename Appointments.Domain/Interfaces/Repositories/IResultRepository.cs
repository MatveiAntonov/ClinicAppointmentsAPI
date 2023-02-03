using Appointments.Domain.Entities;
using Profiles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiles.Domain.Interfaces.Repositories
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result?>> GetAllResults();
        Task<Result?> GetResult(int id);
        Task<Result?> CreateResult(Result result);
        Task<Result?> UpdateResult(Result result);
        Task<Result?> DeleteResult(int id);
    }
}
