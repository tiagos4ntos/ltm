using LTM.Core.Domain;
using LTM.Core.Domain.Entities;
using LTM.Core.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LTM.Core.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly INHSession session;

        public Repository(INHSession session)
        {
            this.session = session;
        }

        protected INHSession Session
        {
            get
            {
                return session;
            }
        }

        public IQueryable<T> Query()
        {
            return this.session.Query<T>();
        }

        public IList<T> ListAll()
        {
            return Query().ToList();
        }

        public T GetById(int id)
        {
            return this.session.Get<T>(id);
        }


        public void SaveOrUpdate(T entity)
        {
            if (entity.IsNew)
                this.session.Insert(entity);
            else
                this.session.Update(entity);
        }

        public void Delete(T entity)
        {
            this.session.Delete(entity);
        }
    }
}
