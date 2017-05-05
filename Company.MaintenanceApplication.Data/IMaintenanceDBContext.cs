using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Data
{
    public interface IMaintenanceDBContext
    {
        IDbSet<T> Set<T>() where T : class;
    }
}
