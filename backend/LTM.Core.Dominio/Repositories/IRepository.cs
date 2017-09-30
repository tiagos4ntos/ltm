using LTM.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Core.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IList<T> ListAll();
        T GetById(int id);
        IQueryable<T> Query();
        void SaveOrUpdate(T entity);
        void Delete(T entity);
    }
}
