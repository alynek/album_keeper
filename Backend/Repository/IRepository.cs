using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Save(T item);
        Task Remove (T item);
        Task Update(T item);
    }
}