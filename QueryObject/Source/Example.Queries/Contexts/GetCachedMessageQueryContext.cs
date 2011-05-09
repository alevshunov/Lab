using Example.Queries.Impl.Caching;

namespace Example.Queries.Contexts
{
	public class GetCachedMessageQueryContext : ICacheContext
	{
		public string GetCacheKey()
		{
			return null;
		}
	}
}