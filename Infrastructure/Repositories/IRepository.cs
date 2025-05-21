namespace Vision.Hive.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetByUserIdAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(Guid id);
    }
    
    
}
