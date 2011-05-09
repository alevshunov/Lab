using System;
using System.Web.Mvc;
using Example.Queries.Infrastructure;

namespace Example.Web.Controllers
{
	public abstract class QueryController : Controller
	{
		private readonly IQueryFactory queryFactory;

		protected QueryController(IQueryFactory queryFactory)
		{
			if(queryFactory == null)
				throw new ArgumentNullException("queryFactory");

			this.queryFactory = queryFactory;
		}

		protected QueryBuilder<TEntity> Query<TEntity>()
		{
			return new QueryBuilder<TEntity>(queryFactory);
		}
	}
}