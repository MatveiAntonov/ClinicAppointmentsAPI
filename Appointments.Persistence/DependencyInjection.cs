using Appointments.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Appointments.Application.Services;
using Appointments.Domain.Interfaces.Repositories;
using Appointments.Domain.Interfaces.Services;
using Appointments.Persistence.Contexts;

namespace Appointments.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConnectDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppointmentsDbContext>(options => {
                options.UseNpgsql(connectionString);
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IResultService, ResultService>();

            return services;
        }
    }
}
