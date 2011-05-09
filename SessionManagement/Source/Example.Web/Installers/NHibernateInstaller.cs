using System;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Example.Web.SessionManagement;
using NHibernate;

namespace Example.Web.Installers
{
	public class NHibernateInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<ISessionWrapper<ISession>>()
			                   	.ImplementedBy<SessionWrapper>().LifeStyle.PerWebRequest);

			container.Register(Component.For<INHibernateInitializer>().ImplementedBy<MyNHibernateInitializer>());
			container.Register(Component.For<ISessionFactory>()
			                   	.UsingFactoryMethod(x => x.Resolve<INHibernateInitializer>()
			                   	                         	.GetConfiguration()
			                   	                         	.BuildSessionFactory())
			                   	.LifeStyle.Is(LifestyleType.Singleton));
		}
	}
}