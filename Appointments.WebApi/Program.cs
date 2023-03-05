using Appointments.Application.Consumer.Events.Services;
using Appointments.Application.Consumer.Events.Doctors;
using Appointments.Persistence;
using Appointments.WebApi.Extensions;
using Appointments.WebApi.Mappings;
using MassTransit;
using Appointments.Application.Consumer.Events.Patients;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.ConnectDatabase(builder.Configuration.GetConnectionString("AppointmentsConnection"));

services.AddAutoMapper(typeof(MappingProfile));

services.AddMassTransit(x =>
{
    x.AddConsumer<ServiceCreatedConsumer>();
    x.AddConsumer<ServiceDeletedConsumer>();
    x.AddConsumer<ServiceUpdatedConsumer>();

    x.AddConsumer<DoctorCreatedConsumer>();
    x.AddConsumer<DoctorDeletedConsumer>();
    x.AddConsumer<DoctorUpdatedConsumer>();

    x.AddConsumer<PatientCreatedConsumer>();
    x.AddConsumer<PatientDeletedConsumer>();
    x.AddConsumer<PatientUpdatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbit-mq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(context);
    });

});

services.AddControllers();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.ConfigureExceptionHandler();

app.Run();

public partial class Program { }
