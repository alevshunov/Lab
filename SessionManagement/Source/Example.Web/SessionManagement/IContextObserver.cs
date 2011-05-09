namespace Example.Web.SessionManagement
{
	public interface IContextObserver
	{
		bool IsCommitAllowed();
	}
}
