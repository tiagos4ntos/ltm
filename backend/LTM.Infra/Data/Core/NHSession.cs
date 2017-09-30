using LTM.Core.Domain;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Linq;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace LTM.Infra.Data.Core
{
    public class NHSession : INHSession
    {
        private ISession session;

        public NHSession(ISession session)
        {
            this.session = session;
        }

        public ISessionImplementor SessionImplementor
        {
            get
            {
                return session.GetSessionImplementation();
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return this.session.Connection;
            }
        }

        public bool IsConnected
        {
            get
            {
                return this.session.IsConnected;
            }
        }

        public bool IsOpen
        {
            get
            {
                return this.session.IsOpen;
            }
        }

        public ITransaction Transaction
        {
            get
            {
                return this.session.Transaction;
            }
        }

        System.Data.IDbConnection INHSession.Connection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ITransaction BeginTransaction()
        {
            return this.session.BeginTransaction();
        }

        public ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return this.session.BeginTransaction(isolationLevel);
        }

        public void Close()
        {
            this.session.Close();
        }

        public ICriteria CreateCriteria<T>() where T : class
        {
            return this.session.CreateCriteria<T>();
        }

        public ICriteria CreateCriteria<T>(string alias) where T : class
        {
            return this.session.CreateCriteria<T>(alias);
        }

        public ICriteria CreateCriteria(string entityName)
        {
            return this.session.CreateCriteria(entityName);
        }

        public ICriteria CreateCriteria(Type entityType)
        {
            return this.session.CreateCriteria(entityType);
        }

        public ICriteria CreateCriteria(string entityName, string alias)
        {
            return this.session.CreateCriteria(entityName, alias);
        }

        public ICriteria CreateCriteria(Type entityType, string alias)
        {
            return this.session.CreateCriteria(entityType, alias);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return this.session.Query<T>();
        }

        public IQuery CreateQuery(string queryString)
        {
            return this.session.CreateQuery(queryString);
        }

        public ISQLQuery CreateSQLQuery(string queryString)
        {
            return this.session.CreateSQLQuery(queryString);
        }

        public void Delete(object entity)
        {
            this.session.Delete(entity);
        }

        public void Delete(string entityName, object entity)
        {
            this.session.Delete(entityName, entity);
        }

        public T Get<T>(object id)
        {
            return this.session.Get<T>(id);
        }

        public T Get<T>(object id, LockMode lockMode)
        {
            return this.session.Get<T>(id, lockMode);
        }

        public object Get(string entityName, object id)
        {
            return this.session.Get(entityName, id);
        }

        public IQuery GetNamedQuery(string queryName)
        {
            return this.session.GetNamedQuery(queryName);
        }

        public ISessionImplementor GetSessionImplementation()
        {
            return this.session.GetSessionImplementation();
        }

        public object Insert(object entity)
        {
            this.session.Save(entity);
            if (this.session.FlushMode != FlushMode.Never)
            {
                this.session.Flush();
            }
            return entity;
        }

        public object Insert(string entityName, object entity)
        {
            this.session.Save(entityName, entity);
            if (this.session.FlushMode != FlushMode.Never)
            {
                this.session.Flush();
            }
            return entity;
        }

        public IQueryOver<T, T> QueryOver<T>() where T : class
        {
            return this.session.QueryOver<T>();
        }

        public IQueryOver<T, T> QueryOver<T>(Expression<Func<T>> alias) where T : class
        {
            return this.session.QueryOver<T>(alias);
        }

        public void Refresh(object entity)
        {
            this.session.Refresh(entity);
        }

        public void Refresh(object entity, LockMode lockMode)
        {
            this.session.Refresh(entity, lockMode);
        }

        public INHSession SetBatchSize(int batchSize)
        {
            this.session = this.session.SetBatchSize(batchSize);
            return this;
        }

        public void Update(object entity)
        {
            this.session.Update(entity);
            if (this.session.FlushMode != FlushMode.Never)
            {
                this.session.Flush();
            }
        }

        public void Update(string entityName, object entity)
        {
            this.session.Update(entityName, entity);
            if (this.session.FlushMode != FlushMode.Never)
            {
                this.session.Flush();
            }
        }
    }
}
