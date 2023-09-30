﻿using System.Linq.Expressions;

namespace TicketEase.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(string id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> FilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(string id, T entity);
        public void SetCollectionName(string collectionName);
    }
}
