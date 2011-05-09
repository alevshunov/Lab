using System;

namespace Example.Web.SessionManagement
{
	public interface ISessionWrapper<out TSession> : IDisposable
	{
		TSession Session { get; }
	}
}
