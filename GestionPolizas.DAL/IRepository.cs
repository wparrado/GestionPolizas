namespace GestionPolizas.DAL
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository
    {
        Task<List<T>> FindAll<T>() where T : class;
        Task<T> FindById<T>(long id) where T : class;
        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
