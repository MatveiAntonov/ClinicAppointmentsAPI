using Appointments.Domain.Entities;
using Appointments.Persistence.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Crypto.Engines;

namespace AppointmentsAPI.IntegrationTests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<AppointmentsDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<AppointmentsDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryAppointmentsTest");
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<AppointmentsDbContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                        Seed(appContext);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            });
        }

        private void Seed(AppointmentsDbContext context)
        {
            var appointments = new List<Appointment>
            {
                new Appointment { Id = 1, PatientId = 1, DoctorId = 1, ServiceId = 1, DateTime =     DateTime.Now, IsApproved = true },
                new Appointment { Id = 2, PatientId = 2, DoctorId = 2, ServiceId = 2, DateTime =     DateTime.Now.AddDays(1), IsApproved = false },
                new Appointment { Id = 3, PatientId = 3, DoctorId = 3, ServiceId = 3, DateTime =     DateTime.Now.AddDays(2), IsApproved = true }
            };

            context.Appointments.AddRange(appointments);
            context.SaveChanges();
        }
    }
}
