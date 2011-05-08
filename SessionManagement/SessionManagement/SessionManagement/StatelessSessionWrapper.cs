using System;
using NHibernate;

namespace SessionManagement.SessionManagement
{
	public class StatelessSessionWrapper : BaseSessionWrapper<IStatelessSession>
	{
		public StatelessSessionWrapper(ISessionFactory sessionFactory) : base(sessionFactory)
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