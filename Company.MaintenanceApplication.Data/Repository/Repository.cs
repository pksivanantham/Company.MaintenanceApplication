using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Data.Repository
{
   public  class Repository<T>:IRepository<T> where T:class
    {
        internal MaintenanceDBContext maintenanceDBContext;
        internal IDbSet<T> dbSet;

        public Repository(MaintenanceDBContext maintenanceDBContext)
        {
            this.maintenanceDBContext = maintenanceDBContext;
            // this.dbSet = maintenanceDBContext.Set<T>();
        }

        public IQueryable<T> Table
        {
            get
            {
                //return dbSet.AsQueryable<T>();
                return Entities;
            }
        }
        public IEnumerable<T> TableAsEnumerable
        {
            get
            {
                IQueryable<T> query = dbSet;
                return query.ToList();

            }
        }

        public virtual T GetById(object Id)
        {
            return Entities.Find(Id);
        }
        public virtual int Insert(T entity)
        {
            var obj = Entities.Add(entity);
            return maintenanceDBContext.SaveChanges();

        }
        public virtual void Delete(Object Id)
        {
            T entityToDelete = Entities.Find(Id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (maintenanceDBContext.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }
            Entities.Remove(entity);
        }
        public virtual int Update(T entity)
        {
            Entities.Attach(entity);
            maintenanceDBContext.Entry(entity).State = EntityState.Modified;
            return maintenanceDBContext.SaveChanges();
        }
        public IDbSet<T> Entities
        {
            get
            {
                if (dbSet == null)
                    dbSet = maintenanceDBContext.Set<T>();
                return dbSet;
            }
        }


    }


}

