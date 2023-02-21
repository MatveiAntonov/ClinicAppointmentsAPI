using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Persistence.EntityTypeConfigurations
{
    public class ServicesConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(service => service.Id);
            builder.HasIndex(service => service.Id).IsUnique();
            builder.Property(service => service.ServiceName).HasMaxLength(350)
                .IsRequired();
            builder.Property(service => service.ServicePrice).HasColumnType("decimal(10,2)")
                .IsRequired(false);
            builder.Property(service => service.ServiceCategoryName).HasMaxLength(350)
                .IsRequired();
            builder.Property(service => service.SpecializationName).HasMaxLength(350)
                .IsRequired();
            builder.Property(service => service.TimeSlotSize)
                .HasColumnType("timestamp")
                .IsRequired(false);
        }
    }
}
