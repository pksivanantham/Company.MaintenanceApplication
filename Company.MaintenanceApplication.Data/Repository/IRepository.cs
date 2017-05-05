using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Data.Repository
{
  public  interface IRepository<T> where T:class 
    {
        IQueryable<T> Table { get; }
        IEnumerable<T> TableAsEnumerable { get; }
        T GetById(object Id);
        int Insert(T entity);
        void Delete(Object Id);
        void Delete(T entity);
        int Update(T Entity);
    }
}
