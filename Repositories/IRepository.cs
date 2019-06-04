using System;
using System.Collections.Generic;

namespace vopen_api.Repositories
{
    public interface IRepository<T>
    {
        T GetById(String id);

        ICollection<T> GetAll();

        void Create(T entity);

        void Delete(T entity);

        void Update(T entity);

    }
}
