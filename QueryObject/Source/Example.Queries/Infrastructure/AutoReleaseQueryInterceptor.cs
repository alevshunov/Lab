using System;
using System.Reflection;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel;

namespace Example.Queries.Infrastructure
{
	[Transient]
	public class AutoReleaseQueryInterceptor : IInterceptor
	{
		private const string MethodName = "Execute";

		private readonly MethodInfo execute;
		private readonly IKernel kernel;

		public AutoReleaseQueryInterceptor(IKernel kernel)
		{
			this.kernel = kernel;
			execute = typeof (IQuery<,>).GetMethod(MethodName);
		}

		public void Intercept(IInvocation invocation)
		{
			if(invocation.Method != execute)
			{
				invocation.Proceed();
				return;
			}

			try
			{
				invocation.Proceed();
			}
			finally
			{
				kernel.ReleaseComponent(invocation.Proxy);
			}
		}
	}
}