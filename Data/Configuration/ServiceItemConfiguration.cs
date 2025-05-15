using BarberAgendado.Domain.Models;
using BarberAgendado.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberAgendado.Data.Configuration
{
    public class ServiceItemConfiguration : IEntityTypeConfiguration<ServiceItem>
    {
        public void Configure(EntityTypeBuilder<ServiceItem> builder)
        {

            builder.ToTable("ServicesItems");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
            builder.Property(s => s.Price)
           .HasColumnType("decimal(19,2)")
           .IsRequired();

            builder.HasIndex(s => s.Name)
                .IsUnique();

            builder.Property(s => s.Duration).IsRequired();
        }
    }
}
