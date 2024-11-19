using LønTransportberegner.Models.Domæne;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LønTransportberegner.Repositories
{
    
        public class Repository<T> : IRepository<T> where T : class
        {
        private readonly ConnectDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ConnectDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }

            public async Task AddAsync(T entity)
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(T entity)
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(T entity)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    
}