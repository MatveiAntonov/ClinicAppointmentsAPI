using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Appointments.Domain.Interfaces.Services;
using Appointments.WebApi.Models.DTOs;
using Appointments.Domain.Entities;
using Appointments.Application.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Profiles.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly IMapper _mapper;
        public ResultController(IResultService resultService, IMapper mapper)
        {
            _resultService = resultService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultDto>>> GetAllResults()
        {
            var results = await _resultService.GetAllResults();
            if (results.Count() != 0)
            {
                var resultsDto = new List<ResultDto>();
                foreach (var result in results)
                {
                    resultsDto.Add(_mapper.Map<ResultDto>(result));
                }
                return Ok(results);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultDto>> GetResult(int id)
        {
            var result = await _resultService.GetResult(id);
            if (result is not null)
            {
                var resultDto = _mapper.Map<ResultDto>(result);
                return Ok(resultDto);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Receptionist")]
        public async Task<ActionResult> CreateResult([FromForm] ResultDto entity)
        {
            if (entity == null)
                return BadRequest();

            var resultToCreate = _mapper.Map<Result>(entity);

            var result = await _resultService.CreateResult(resultToCreate);
            if (result != false)
            {
                return Created($"/result/{entity.Id}", entity);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Receptionist")]
        public async Task<ActionResult> UpdateResult(int id, [FromForm] ResultDto entity)
        {
            if (entity == null)
                return BadRequest();

            var checkResult = await _resultService.GetResult(id);
            if (checkResult is null)
            {
                return NotFound();
            }

            var resultToUpdate = _mapper.Map<Result>(entity);

            var result = await _resultService.UpdateResult(id, resultToUpdate);
            if (result != false)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Receptionist")]
        public async Task<ActionResult> DeleteResult(int id)
        {
            if (await _resultService.GetResult(id) is null)
            {
                return BadRequest();
            };

            var result = await _resultService.DeleteResult(id);
            if (result != false)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
