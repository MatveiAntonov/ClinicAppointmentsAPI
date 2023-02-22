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
            builder.HasOne(appointment => appointment.Service)
                .WithMany()
                .HasForeignKey(appointment => appointment.ServiceId);
            builder.HasOne(appointment => appointment.Doctor)
                .WithMany()
                .HasForeignKey(appointment => appointment.DoctorId);
            builder.HasOne(appointment => appointment.Patient)
                .WithMany()
                .HasForeignKey(appointment => appointment.PatientId);
        }
    }
}
