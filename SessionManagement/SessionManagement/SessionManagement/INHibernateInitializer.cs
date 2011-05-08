using NHibernate.Cfg;

namespace SessionManagement.SessionManagement
{
	///<summary>
	///	Bootstrapper for nhibernate
	///</summary>
	public interface INHibernateInitializer
	{
		///<summary>
		///	Builds and returns nhibernate configuration
		///</summary>
		///<returns>NHibernate configuration object</returns>
		Configuration GetConfiguration();
	}
}