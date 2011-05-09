using Example.Queries.Infrastructure;

namespace Example.Queries.Impl.Caching
{
	public abstract class CachedQuery<TContext, TResult> : IQuery<TContext, TResult>
		where TContext : ICacheContext
	{
		private readonly ICacheStrategy cacheStrategy;

		protected CachedQuery(ICacheStrategy cacheStrategy)
		{
			this.cacheStrategy = cacheStrategy;
		}

		public TResult Execute(TContext context)
		{
			string cacheKey = context.GetCacheKey();
			object fromCache = cacheStrategy.Get(cacheKey);

			if(fromCache != null)
				return (TResult) fromCache;

			TResult result = ExecuteCore(context);

			cacheStrategy.Put(cacheKey, result);

			return result;
		}

		protected abstract TResult ExecuteCore(TContext context);
	}
}