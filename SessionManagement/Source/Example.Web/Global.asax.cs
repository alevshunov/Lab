using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Example.Web.IoC;

namespace Example.Web
{
	public class MvcApplication : HttpApplication, IContainerAccessor
	{
		private readonly object lockObject = new object();
		private IWindsorContainer container;

		public IWindsorContainer Container
		{
			get
			{
				if(container != null)
					return container;

				lock (lockObject)
				{
					if(container == null)
						container = new WebAppContainer();
				}
				return container;
			}
		}

		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("favicon.ico");

			routes.MapRoute("Default",
			                "{controller}/{action}/{id}",
			                new {controller = "Home", action = "Index", id = UrlParameter.Optional});
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container));
		}
	}
}
