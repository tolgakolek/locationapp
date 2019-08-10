using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;
        ParameterExpression entity = Expression.Parameter(typeof(T), "ent");

        public Repository(DbContext DbContext)
        {
            dbContext = DbContext;
            dbSet = DbContext.Set<T>();
        }
        public void Delete(T Entity)
        {
            if (dbContext.Entry(Entity).State == EntityState.Detached) //Concurrency için 
            {
                dbSet.Attach(Entity);
            }
            dbSet.Remove(Entity);
        }
        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault();
        }
        public void Insert(T Entity)
        {
            dbSet.Add(Entity);
        }
        public void Update(T Entity)
        {
            dbSet.Attach(Entity);
            dbContext.Entry(Entity).State = EntityState.Modified;
        }     
        IQueryable<T> IRepository<T>.Select(Expression<Func<T, bool>> where, Expression<Func<T, dynamic>> select)
        {
            if (where != null)
            {
                return dbSet;
            }

            return dbSet;
        }
       
    }
}
