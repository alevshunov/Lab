using NHibernate;

namespace Example.Web.SessionManagement
{
	public class SessionWrapper : BaseSessionWrapper<ISession>
	{
		public SessionWrapper(ISessionFactory sessionFactory, IContextObserver contextObserver) : base(sessionFactory, contextObserver)
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
