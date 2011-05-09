using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Example.Web.IoC
{
	public class WebAppContainer : WindsorContainer
	{
		public WebAppContainer()
		{
			Install(FromAssembly.This());
		}
	}
}
