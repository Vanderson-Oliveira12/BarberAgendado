using BarberAgendado.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberAgendado.Data.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ScheduledAt).IsRequired();


            builder.HasOne(a => a.Customer)
                .WithMany()
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Barber)
                .WithMany()
                .HasForeignKey(a => a.BarberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.ServiceItem)
                .WithMany()
                .HasForeignKey(a => a.ServiceItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
