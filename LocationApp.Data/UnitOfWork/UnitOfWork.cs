using LocationApp.Data.Database;
using LocationApp.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfwork
    {
        private locationappEntities dbC;
        public bool dispose = false;

        public UnitOfWork()
        {
            dbC = new locationappEntities();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(dbC);
        }
        public int saveChanges()
        {
            try
            {
                return dbC.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                {
                    dbC.Dispose();
                }
            }
            this.dispose = true;
        }
    }
}
