using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Markel.Claims.Service.Data
{
    public interface IGenericRepository<T> where T:class
    {
        public Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Update(T entity);
    }
}
