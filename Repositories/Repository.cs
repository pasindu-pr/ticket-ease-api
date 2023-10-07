using MongoDB.Driver;
using TicketEase.Contracts;

namespace TicketEase.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IMongoCollection<T> dbCollection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;
        private IMongoDatabase _database;

        public Repository(IMongoDatabase database)
        {
            _database = database;
            dbCollection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> CreateAsync(T entity)
        {
            //Generic Method For Create Operation
            await dbCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            await dbCollection.DeleteOneAsync(filterBuilder.Eq("Id", id));
        }

        public async Task<IReadOnlyCollection<T>> FilterAsync(FilterDefinition<T> filter)
        {
            return await dbCollection.Find(filter).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return await dbCollection.Find(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await dbCollection.Find(filterBuilder.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async void SetCollectionName(string collectionName)
        {
            dbCollection = _database.GetCollection<T>(collectionName);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await dbCollection.ReplaceOneAsync(filterBuilder.Eq("Id", id), entity);
        }
    }
}
