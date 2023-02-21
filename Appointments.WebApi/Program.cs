using Appointments.Application.Consumer.Events;
using Appointments.Persistence;
using Appointments.WebApi.Extensions;
using Appointments.WebApi.Mappings;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.ConnectDatabase(builder.Configuration.GetConnectionString("AppointmentsConnection"));

services.AddAutoMapper(typeof(MappingProfile));

services.AddMassTransit(x =>
{
    x.AddConsumer<ServiceCreatedConsumer>();
    x.AddConsumer<ServiceDeletedConsumer>();
    x.AddConsumer<ServiceUpdatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
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
