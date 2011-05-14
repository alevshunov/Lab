namespace Example.Queries.Infrastructure
{
	/// <summary>
	/// This interface does not have explicit implementation. Implementation provided by TypedFactory facility of Castle Windsor
	/// </summary>
	public interface IQueryFactory
	{
		IQuery<TQueryContext, TResult> Create<TQueryContext, TResult>();
	}
}