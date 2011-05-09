namespace Example.Queries.Infrastructure
{
	/// <summary>
	/// 	��������� ������� ��� �������� query. ����������� ������ � ������� TypedFactoryFacility Castle Windsor
	/// </summary>
	public interface IQueryFactory
	{
		IQuery<TQueryContext, TResult> Create<TQueryContext, TResult>();
	}
}