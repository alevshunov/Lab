using NHibernate.Cfg;

namespace SessionManagement.SessionManagement
{
	public class MyNHibernateInitializer : INHibernateInitializer
	{
		public Configuration GetConfiguration()
		{
			//here you can configure how NHibernate will be
			//bootstrapped (via xml config or fluently or other way you want)
			return new Configuration();
		}
	}
}