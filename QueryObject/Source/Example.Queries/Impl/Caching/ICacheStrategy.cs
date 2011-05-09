namespace Example.Queries.Impl.Caching
{
	public interface ICacheStrategy
	{
		object Get(string key);
		void Put(string cacheKey, object result);
	}
}