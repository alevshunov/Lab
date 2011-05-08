using NHibernate;

namespace SessionManagement.SessionManagement
{
	public class SessionWrapper : BaseSessionWrapper<ISession>
	{
		public SessionWrapper(ISessionFactory sessionFactory)
			: base(sessionFactory)
		{
		}

		protected override ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}

		protected override ITransaction BeginTransaction(ISession session)
		{
			return session.BeginTransaction();
		}
	}
}