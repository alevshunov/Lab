using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Example.Queries.Impl.Caching;

namespace Example.Web.Installers
{
	public class CommonInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<ICacheStrategy>().ImplementedBy<SingleObjectCacheStrategy>());
		}
	}
}