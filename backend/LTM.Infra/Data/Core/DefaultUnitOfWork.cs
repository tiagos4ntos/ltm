using LTM.Core.Domain;
using NHibernate;
using System;
using System.Data;

namespace LTM.Infra.Data.Core
{
    public class DefaultUnitOfWork : INHUnitOfWork
    {
        public INHSession Session { get; private set; }

        private ITransaction _transaction;

        private DefaultUnitOfWork(INHSession session, IsolationLevel isolationLevel)
        {
            this.Session = session;

            if (Session.Transaction != null && Session.Transaction.IsActive)
            {
                Session.Transaction.Dispose();
            }

            this._transaction = this.Session.BeginTransaction(isolationLevel);
        }

        public static INHUnitOfWork ReadCommitted(INHSession session)
        {
            return new DefaultUnitOfWork(session, IsolationLevel.ReadCommitted);
        }

        public static INHUnitOfWork Snapshot(INHSession session)
        {
            return new DefaultUnitOfWork(session, IsolationLevel.Snapshot);
        }

        public void Commit()
        {
            if (!this._transaction.IsActive)
            {
                throw new InvalidOperationException("There is no active transaction. The commit can not be executed");
            }

            this._transaction.Commit();
            this.Session.GetSessionImplementation().Flush();
        }

        public void Rollback()
        {
            try
            {
                if (this._transaction.IsActive && !this._transaction.WasCommitted && !this._transaction.WasRolledBack)
                {
                    this.Session.GetSessionImplementation().Flush();
                    this._transaction.Rollback();
                }
            }
            catch (Exception) { }
        }

        void IDisposable.Dispose()
        {
            this.Rollback();
        }
    }
}
