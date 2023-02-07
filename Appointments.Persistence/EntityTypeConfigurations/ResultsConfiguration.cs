using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointments.Persistence.EntityTypeConfigurations
{
    public class ResultsConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasKey(result => result.Id);
            builder.HasIndex(result => result.Id).IsUnique();
            builder.HasOne(result => result.Appointment)
                .WithOne()
                .HasForeignKey<Result>(result => result.AppointmentId);
        }
    }
}
