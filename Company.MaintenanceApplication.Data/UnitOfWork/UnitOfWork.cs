using Company.MaintenanceApplication.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Data.UnitOfWork
{
   public class UnitOfWork :IUnitOfWork
    {
        private readonly MaintenanceDBContext _maintenenceDBContext;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork()
        {
            _maintenenceDBContext = new MaintenanceDBContext();
        }

        public UnitOfWork(MaintenanceDBContext maintenenctDBContext)
        {
            this._maintenenceDBContext = maintenenctDBContext;
        }

        public void Save()
        {
            _maintenenceDBContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {

            if(!_disposed)
            {
                if(disposing)
                {
                    _maintenenceDBContext.Dispose();
                    _disposed = true;
                }
            }
        }

        public IRepository<T> Repository<T>() where T:class
        {
            if (_repositories == null)
                _repositories = new Hashtable();
            var type = typeof(T).Name;
            if(!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof( Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _maintenenceDBContext);
                _repositories.Add(type, repositoryInstance);
            }
            return (IRepository<T>)_repositories[type];
        }


    }
}
