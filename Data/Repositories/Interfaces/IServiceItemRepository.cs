using BarberAgendado.Domain.DTOs.ServicesItems;
using BarberAgendado.Domain.Models;

namespace BarberAgendado.Data.Repositories.Interfaces
{
    public interface IServiceItemRepository : IRepository<ServiceItem>
    {
        Task<ServiceItem> GetByNameAsync(string name);
    }
}
