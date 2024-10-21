namespace DotNet.Services.Repositories.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> GetByID(int id);
        Task Add(T entity);

        //void Delete(T entity);
        void Update(T entity);
        //Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
