using BarberAgendado.Data.Context;
using BarberAgendado.Data.Repositories.Interfaces;
using BarberAgendado.Domain.DTOs.ServicesItems;
using BarberAgendado.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberAgendado.Data.Repositories
{
    public class ServiceItemRepository : Repository<ServiceItem>, IServiceItemRepository
    {
        private AppDbContext _context;
        public ServiceItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ServiceItem> GetByNameAsync(string name)
             => await _context.ServiceItem.Where(s => s.Name == name).FirstOrDefaultAsync();
    }
}
