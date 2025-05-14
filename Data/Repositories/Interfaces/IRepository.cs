using BarberAgendado.Domain.Models;

namespace BarberAgendado.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
       Task<IEnumerable<T>> GetAllAsync();
       Task<T> GetByIdAsync(string id);
       Task<T> CreateAsync(T entity);
       Task<T> UpdateAsync(T entity);
       Task<T> RemoveAsync(T entity);
    }
}
