using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T GetById(Guid id);
        void Add(T entity);
        void Delete(Guid id);
        void Update(T entity);
    }
}
