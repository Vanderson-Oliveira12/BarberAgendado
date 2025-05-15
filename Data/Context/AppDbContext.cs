using BarberAgendado.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberAgendado.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceItem> ServiceItem { get; set; }
        public DbSet<Barber> Barbers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
