using Appointments.Domain.Entities;
using Appointments.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Persistence.Contexts
{
    public class AppointmentsDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Result> Results { get; set; }

        public AppointmentsDbContext(DbContextOptions<AppointmentsDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppointmentsConfiguration());
            builder.ApplyConfiguration(new ResultsConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
