using HeatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeatApp.Persistence.Configurations;

public class HeatConfiguration : IEntityTypeConfiguration<Heat>
{
    public void Configure(EntityTypeBuilder<Heat> builder)
    {
        builder.Property(c => c.DeviceId).IsRequired();
        builder.Property(c => c.HeatValue).HasDefaultValue(0).IsRequired();
    }
}