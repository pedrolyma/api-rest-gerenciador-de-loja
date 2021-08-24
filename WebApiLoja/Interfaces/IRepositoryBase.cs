using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLoja.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
    }
}
