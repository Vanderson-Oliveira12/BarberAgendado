using BarberAgendado.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BarberAgendado.Configurations
{
    public static class DbContextConfiguration
    {
        public static void AddDbContextConfig(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DbConnection");

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}
