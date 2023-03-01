namespace Movie_Characters_API.Services
{
    public interface ICrudService <T, ID>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(ID id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(ID id);
    }
}
