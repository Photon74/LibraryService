using System.Collections.Generic;

namespace LibraryService.Services
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        T GetById(string id);
    }
}
