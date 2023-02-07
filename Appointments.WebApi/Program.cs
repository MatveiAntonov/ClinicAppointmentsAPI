using Appointments.Persistence;
using Appointments.WebApi.Extensions;
using Appointments.WebApi.Mappings;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.ConnectDatabase(builder.Configuration.GetConnectionString("AppointmentsConnection"));

services.AddAutoMapper(typeof(MappingProfile));

services.AddControllers();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.ConfigureExceptionHandler();

app.Run();
