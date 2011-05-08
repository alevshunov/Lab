using System;

namespace SessionManagement.SessionManagement
{
	public interface ISessionWrapper<out TSession> : IDisposable
	{
		TSession Session { get; }
	}
}