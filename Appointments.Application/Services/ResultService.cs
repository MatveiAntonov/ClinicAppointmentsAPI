
using Appointments.Domain.Entities;
using Profiles.Domain.Interfaces.Services;

namespace Profiles.Application.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultService _resultRepository;
        public ResultService(IResultService repository)
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

        public async Task<Result?> CreateResult(Result result)
        {
            var createdResult = await _resultRepository.CreateResult(result);

            return createdResult;
        }

        public async Task<Result?> UpdateResult(Result result)
        {
            var updatedResult = await _resultRepository.UpdateResult(result);

            return updatedResult;
        }
        public async Task<Result?> DeleteResult(int id)
        {
            var deletedResult = await _resultRepository.DeleteResult(id);

            return deletedResult;
        }
    }
}
