using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SessionManagement.IoC
{
	public class WebAppContainer : WindsorContainer
	{
		public WebAppContainer()
		{
			Install(FromAssembly.This());
		}
	}
}