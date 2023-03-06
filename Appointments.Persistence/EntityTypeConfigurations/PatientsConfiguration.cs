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
    public class PatientsConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(doctor => doctor.Id);
            builder.HasIndex(doctor => doctor.Id).IsUnique();
            builder.Property(doctor => doctor.FirstName).IsRequired();
            builder.Property(doctor => doctor.LastName).IsRequired();
            builder.Property(doctor => doctor.PhotoUrl).IsRequired();
            builder.Property(doctor => doctor.DateOfBirth).IsRequired();
        }
    }
}
