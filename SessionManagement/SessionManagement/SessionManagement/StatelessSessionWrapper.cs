using System;
using NHibernate;

namespace SessionManagement.SessionManagement
{
	public class StatelessSessionWrapper : BaseSessionWrapper<IStatelessSession>
	{
		public StatelessSessionWrapper(ISessionFactory sessionFactory, IContextObserver contextObserver) : base(sessionFactory, contextObserver)
		{
		}

		protected override IStatelessSession OpenSession()
		{
			return SessionFactory.OpenStatelessSession();
		}

		protected override ITransaction BeginTransaction(IStatelessSession session)
		{
			return session.BeginTransaction();
		}
	}
}