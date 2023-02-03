using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Profiles.Persistence.Contexts
{
    public class AppointmentsDbContext : DbContext, IAppointmentsDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Result> Results { get; set; }

        public AppointmentsDbContext(DbContextOptions<AppointmentsDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DocumentsConfiguration());
            builder.ApplyConfiguration(new PhotoConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
