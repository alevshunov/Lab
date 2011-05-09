using System;
using NHibernate;

namespace Example.Web.SessionManagement
{
	public abstract class BaseSessionWrapper<TSession> : ISessionWrapper<TSession>
		where TSession : class, IDisposable
	{
		private readonly IContextObserver contextObserver;
		private readonly ISessionFactory sessionFactory;
		private bool disposed;
		private TSession session;
		private ITransaction transaction;

		protected BaseSessionWrapper(ISessionFactory sessionFactory, IContextObserver contextObserver)
		{
			if(sessionFactory == null)
				throw new ArgumentNullException("sessionFactory");
			if(contextObserver == null)
				throw new ArgumentNullException("contextObserver");

			this.sessionFactory = sessionFactory;
			this.contextObserver = contextObserver;
		}

		public TSession Session
		{
			get
			{
				if(disposed)
					throw new InvalidOperationException("Object already disposed. Probably container has wrong lifestyle type");

				if(session != null)
					return session;

				session = OpenSession();
				transaction = BeginTransaction(session);

				return session;
			}
		}

		protected ISessionFactory SessionFactory
		{
			get { return sessionFactory; }
		}

		public void Dispose()
		{
			if(disposed)
				return;

			if(session == null)
				return;

			try
			{
				if(CanCommit())
					transaction.Commit();
				else
					transaction.Rollback();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
			finally
			{
				transaction.Dispose();
			}

			session.Dispose();
			session = null;
			transaction = null;
			disposed = true;
		}

		protected abstract TSession OpenSession();
		protected abstract ITransaction BeginTransaction(TSession session);

		private bool CanCommit()
		{
			return contextObserver.IsCommitAllowed();
		}
	}
}
