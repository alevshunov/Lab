using System;
using Example.Queries.Contexts;
using Example.Queries.Impl.Caching;

namespace Example.Queries.Impl
{
	public class GetCachedMessageQuery : CachedQuery<GetCachedMessageQueryContext, string>
	{
		public GetCachedMessageQuery(ICacheStrategy cacheStrategy) : base(cacheStrategy)
		{
		}

		protected override string ExecuteCore(GetCachedMessageQueryContext context)
		{
			return string.Format("Cached message, created at {0}", DateTime.Now);
		}
	}
}