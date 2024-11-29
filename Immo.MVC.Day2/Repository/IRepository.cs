using Microsoft.AspNetCore.Mvc.Rendering;

namespace Immo.MVC.Day2.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(int id);
    }

    public interface IRepositoryWithCategory<T> : IRepository<T> where T: class
    {
        Task<IEnumerable<SelectListItem>> Categories();
    }
}
