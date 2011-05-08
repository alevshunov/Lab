using Castle.Core.Resource;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor.Installer;

namespace SessionManagement.IoC
{
	public class WebAppContainer : WindsorContainer
	{
		public WebAppContainer() : base(new XmlInterpreter(new ConfigResource()))
		{
			Install(FromAssembly.This());
		}
	}
}