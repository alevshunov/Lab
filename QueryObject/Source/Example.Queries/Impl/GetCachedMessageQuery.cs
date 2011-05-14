using System;
using Example.Queries.Contexts;
using Example.Queries.Impl.Caching;
using Example.Queries.Results;

namespace Example.Queries.Impl
{
	public class GetCachedMessageQuery : CachedQuery<GetCachedMessageQueryContext, Message>
	{
		public GetCachedMessageQuery(ICacheStrategy cacheStrategy) : base(cacheStrategy)
		{
		}

		protected override Message ExecuteCore(GetCachedMessageQueryContext context)
		{
			string text = string.Format("Cached message created at {0}", DateTime.Now);

			return new Message(1, text);
		}
	}
}