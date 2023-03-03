namespace Movie_Characters_API.Services
{
    public interface ICrudService <T, ID>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(ID id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task Delete(ID id);
    }
}
