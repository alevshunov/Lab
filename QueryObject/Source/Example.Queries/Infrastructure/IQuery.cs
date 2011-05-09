namespace Example.Queries.Infrastructure
{
	public interface IQuery<in TQueryContext, out TResult>
	{
		TResult Execute(TQueryContext context);
	}
}