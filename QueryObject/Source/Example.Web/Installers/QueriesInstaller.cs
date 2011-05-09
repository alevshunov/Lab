using System;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Example.Queries.Impl;
using Example.Queries.Infrastructure;

namespace Example.Web.Installers
{
	public class QueriesInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			//queries
			var queries = AllTypes.FromAssemblyContaining<GetWelcomeMessageQuery>()
				.BasedOn(typeof (IQuery<,>))
				.WithService.FirstInterface()
				.Configure(x => x.LifeStyle.Transient
				                	.Interceptors<AutoReleaseQueryInterceptor>());
			container.Register(queries);

			container.Register(Component.For<IQueryFactory>().AsFactory());
			container.Register(Component.For<AutoReleaseQueryInterceptor>());
		}
	}
}