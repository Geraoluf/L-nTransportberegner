﻿using System.Linq.Expressions;

namespace LønTransportberegner.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        public List<T> GetFiltered(Func<T, bool> filter);
    }
}
