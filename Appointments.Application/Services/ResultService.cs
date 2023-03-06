using Appointments.Domain.Interfaces.Repositories;
using Appointments.Domain.Interfaces.Services;
using Appointments.Domain.Entities;

namespace Appointments.Application.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        public ResultService(IResultRepository repository)
        {
            _resultRepository = repository;
        }

        public async Task<IEnumerable<Result?>> GetAllResults()
        {
            var results = await _resultRepository.GetAllResults();

            return results;
        }

        public async Task<Result?> GetResult(int id)
        {
            var result = await _resultRepository.GetResult(id);

            return result;
        }

        public async Task<bool> CreateResult(Result result)
        {
            if (result is null)
            {
                return false;
            }

            var createResult = await _resultRepository.CreateResult(result);

            return createResult;
        }

        public async Task<bool> UpdateResult(int id,Result result)
        {
            if (result is null)
            {
                return false;
            }

            Result resultToUpdate = await _resultRepository.GetResult(id);

            if (resultToUpdate is null)
            {
                return false;
            }

            var updateResult = _resultRepository.UpdateResult(resultToUpdate, result);

            return updateResult;
        }

        public async Task<bool> DeleteResult(int id)
        {
            Result result = await _resultRepository.GetResult(id);
            if (result is null)
            {
                return false;
            }

            var deleteResult = _resultRepository.DeleteResult(result);

            return deleteResult;
        }
    }
}
