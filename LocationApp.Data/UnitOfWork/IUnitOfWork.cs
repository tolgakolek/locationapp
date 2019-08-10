using LocationApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.UnitOfWork
{
    interface IUnitOfwork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int saveChanges();
    }
}
