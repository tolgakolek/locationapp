using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Repository
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(Expression<Func<T, bool>> predicate);
        IQueryable<T> Select(Expression<Func<T, bool>> where, Expression<Func<T, dynamic>> select);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
