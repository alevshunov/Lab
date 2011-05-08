using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SessionManagement.Controllers;

namespace SessionManagement.IoC
{
	public class WindsorControllerFactory : DefaultControllerFactory
	{
		private readonly IWindsorContainer container;

		public WindsorControllerFactory(IWindsorContainer container)
		{
			this.container = container;

			var descriptor = AllTypes.FromAssemblyContaining<HomeController>()
				.BasedOn<Controller>()
				.Configure(c => c.LifeStyle.Transient);

			container.Register(descriptor);
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if(controllerType == null)
				throw new HttpException(404,
				                        string.Format(
				                        	"The controller for path '{0}' could not be found or it does not implement IController.",
				                        	requestContext.HttpContext.Request.Path));


			return (IController) container.Resolve(controllerType);
		}

		public override void ReleaseController(IController controller)
		{
			var disposable = controller as IDisposable;

			if(disposable != null)
				disposable.Dispose();

			container.Release(controller);
		}
	}
}