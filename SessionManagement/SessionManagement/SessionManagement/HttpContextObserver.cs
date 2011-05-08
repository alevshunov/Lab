using System.Linq;
using System.Web;

namespace SessionManagement.SessionManagement
{
	public class HttpContextObserver : IContextObserver
	{
		public bool IsCommitAllowed()
		{
			var allErrors = HttpContext.Current.AllErrors;
			
			return allErrors != null && allErrors.Any();
		}
	}
}