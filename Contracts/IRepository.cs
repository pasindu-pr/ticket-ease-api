using MongoDB.Driver;
using System.Linq.Expressions;

namespace TicketEase.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(string id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<IReadOnlyCollection<T>> FilterAsync(FilterDefinition<T> filter);
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(string id, T entity);
        public void SetCollectionName(string collectionName);
    }
}
