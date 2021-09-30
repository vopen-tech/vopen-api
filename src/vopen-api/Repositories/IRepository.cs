using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vopen_api.Models;

namespace vopen_api.Repositories
{
    public interface IMultiLanguageRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllByLanguage(string language);

        Task<T> GetByLanguageAndId(string language, string id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(string id);
    }
}
