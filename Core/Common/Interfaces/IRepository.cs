using System;
using System.Linq.Expressions;

namespace Core.Common.Interfaces
{
	public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        Task Save();
    }
}

