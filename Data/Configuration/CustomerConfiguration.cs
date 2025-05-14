using BarberAgendado.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberAgendado.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(80);
            builder.Property(c => c.Email).IsRequired().HasColumnType("VARCHAR(255)");
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(c => c.UpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
        }
    }
}
