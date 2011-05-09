namespace Example.Queries.Impl.Caching
{
	public class SingleObjectCacheStrategy : ICacheStrategy
	{
		private object storage;

		public object Get(string key)
		{
			return storage;
		}

		public void Put(string cacheKey, object result)
		{
			storage = result;
		}
	}
}