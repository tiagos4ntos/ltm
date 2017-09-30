using NHibernate;
using NHibernate.Engine;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace LTM.Core.Domain
{
    public interface INHSession
    {
        ISessionImplementor SessionImplementor { get; }

        IDbConnection Connection { get; }
        bool IsConnected { get; }
        bool IsOpen { get; }
        ITransaction Transaction { get; }

        ITransaction BeginTransaction();
        ITransaction BeginTransaction(IsolationLevel isolationLevel);
        void Close();
        ICriteria CreateCriteria<T>() where T : class;
        ICriteria CreateCriteria<T>(string alias) where T : class;
        ICriteria CreateCriteria(string entityName);
        ICriteria CreateCriteria(Type entityType);
        ICriteria CreateCriteria(string entityName, string alias);
        ICriteria CreateCriteria(Type entityType, string alias);
        IQueryable<T> Query<T>() where T : class;
        IQuery CreateQuery(string queryString);
        ISQLQuery CreateSQLQuery(string queryString);
        void Delete(object entity);
        void Delete(string entityName, object entity);
        T Get<T>(object id);
        T Get<T>(object id, LockMode lockMode);
        object Get(string entityName, object id);
        IQuery GetNamedQuery(string queryName);
        ISessionImplementor GetSessionImplementation();
        object Insert(object entity);
        object Insert(string entityName, object entity);
        IQueryOver<T, T> QueryOver<T>() where T : class;
        IQueryOver<T, T> QueryOver<T>(Expression<Func<T>> alias) where T : class;
        void Refresh(object entity);
        void Refresh(object entity, LockMode lockMode);
        INHSession SetBatchSize(int batchSize);
        void Update(object entity);
        void Update(string entityName, object entity);
    }
}
