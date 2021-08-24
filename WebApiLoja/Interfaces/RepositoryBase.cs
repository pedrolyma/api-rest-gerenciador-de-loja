using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLoja.Interfaces
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public IQueryable<T> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
