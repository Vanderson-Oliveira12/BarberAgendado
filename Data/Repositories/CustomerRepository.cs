using BarberAgendado.Data.Context;
using BarberAgendado.Data.Repositories.Interfaces;
using BarberAgendado.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberAgendado.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetByEmailAsync(string email) =>
               await _context.Customers.Where(c => c.Email == email).FirstOrDefaultAsync();
    }
}
