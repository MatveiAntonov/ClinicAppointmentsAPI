using Microsoft.EntityFrameworkCore;
using Appointments.Persistence.Contexts;
using Appointments.Domain.Interfaces.Repositories;
using Appointments.Domain.Entities;
using Appointments.Application.Logic;
using Events;
using MassTransit;

namespace Appointments.Persistence.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppointmentsDbContext _appointmentsDbContext;
		private readonly IPublishEndpoint _publishEndpoint;

		public ResultRepository(AppointmentsDbContext appointmentsDbContext, IPublishEndpoint publishEndpoint)
        {
            _appointmentsDbContext = appointmentsDbContext;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<IEnumerable<Result?>> GetAllResults()
        {
            return await _appointmentsDbContext.Results
                .Include(result => result.Appointment)
                .Include(result => result.Appointment.Service)
                .Include(result => result.Appointment.Doctor)
                .Include(result => result.Appointment.Patient)
                .ToListAsync();
        }
        public async Task<Result?> GetResult(int id)
        {
            return await _appointmentsDbContext.Results
                .Include(result => result.Appointment)
                .Include(result => result.Appointment.Service)
                .Include(result => result.Appointment.Doctor)
                .Include(result => result.Appointment.Patient)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> CreateResult(Result result)
        {
            try
            {
                var appointment = _appointmentsDbContext.Appointments
                    .FirstOrDefault(appointment => appointment.Id == result.AppointmentId);

                if (appointment is not null)
                {
                    result.Appointment = appointment;

                    await _appointmentsDbContext.Results.AddAsync(result);
                    _appointmentsDbContext.SaveChanges();

                    var pdf = PdfGenerator.CreatePDF(result.Complaints, result.Conclusion, result.Recomendations);

                    await _publishEndpoint.Publish<ResultCreated>(new
                    {
                        Id = result.Id,
                        Document = pdf
                    });

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateResult(Result result, Result entity)
        {
            try
            {
                var appointment = _appointmentsDbContext.Appointments
                    .FirstOrDefault(appointment => appointment.Id == result.AppointmentId);

                if (appointment is not null)
                {
                    result.Complaints = entity.Complaints;
                    result.Conclusion = entity.Conclusion;
                    result.Recomendations = entity.Recomendations;
                    result.AppointmentId = entity.AppointmentId;

                    _appointmentsDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteResult(Result result)
        {
            try
            {
                _appointmentsDbContext.Results.Remove(result);
                _appointmentsDbContext.SaveChanges();

                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
