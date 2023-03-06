using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Persistence.EntityTypeConfigurations
{
    public class DoctorsConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(doctor => doctor.Id);
            builder.HasIndex(doctor => doctor.Id).IsUnique();
            builder.Property(doctor => doctor.FirstName).IsRequired();
            builder.Property(doctor => doctor.LastName).IsRequired();
            builder.Property(doctor => doctor.SpecializationName).HasMaxLength(400)
                .IsRequired();
            builder.Property(doctor => doctor.PhotoUrl).IsRequired();
            builder.Property(doctor => doctor.OfficeName).IsRequired();
            builder.Property(doctor => doctor.OfficeCity).IsRequired();
            builder.Property(doctor => doctor.OfficeRegion).IsRequired();
            builder.Property(doctor => doctor.OfficeStreet).IsRequired();
            builder.Property(doctor => doctor.OfficePostalCode).IsRequired();
            builder.Property(doctor => doctor.OfficeHouseNumber).IsRequired();
        }
    }
}
