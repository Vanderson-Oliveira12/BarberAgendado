using BarberAgendado.Data.Context;
using BarberAgendado.Data.Repositories.Interfaces;
using BarberAgendado.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberAgendado.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
                await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(string id) =>
            await _dbSet.Where(t => t.Id == id).FirstOrDefaultAsync();

        public async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
