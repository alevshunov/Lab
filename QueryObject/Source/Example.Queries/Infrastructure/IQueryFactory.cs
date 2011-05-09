namespace Example.Queries.Infrastructure
{
	/// <summary>
	/// 	Интерфейс фабрики для создания query. Реализуется НЕЯВНО с помощью TypedFactoryFacility Castle Windsor
	/// </summary>
	public interface IQueryFactory
	{
		IQuery<TQueryContext, TResult> Create<TQueryContext, TResult>();
	}
}