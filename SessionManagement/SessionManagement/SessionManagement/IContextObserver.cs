namespace SessionManagement.SessionManagement
{
	public interface IContextObserver
	{
		bool IsCommitAllowed();
	}
}