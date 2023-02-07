using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointments.Persistence.EntityTypeConfigurations
{
    public class AppointmentsConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(appointment => appointment.Id);
            builder.HasIndex(appointment => appointment.Id).IsUnique();
            builder.Property(appointment => appointment.DoctorId)
                .IsRequired();
            builder.Property(appointment => appointment.PatientId)
                .IsRequired();
            builder.Property(appointment => appointment.DateTime)
                .HasColumnType("timestamp");
        }
    }
}
