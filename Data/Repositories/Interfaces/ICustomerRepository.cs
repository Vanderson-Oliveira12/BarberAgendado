using BarberAgendado.Domain.Models;

namespace BarberAgendado.Data.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByEmailAsync(string email);
    }
}
