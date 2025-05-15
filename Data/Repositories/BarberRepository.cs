using BarberAgendado.Data.Context;
using BarberAgendado.Data.Repositories.Interfaces;
using BarberAgendado.Domain.Models;

namespace BarberAgendado.Data.Repositories
{
    public class BarberRepository : Repository<Barber>, IBarberRepository
    {
        private AppDbContext _context;
        public BarberRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
