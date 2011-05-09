using System;
using System.Collections.Generic;

namespace Example.Queries.Infrastructure
{
	public class QueryBuilder<TResult>
	{
		private readonly IQueryFactory queryFactory;

		public QueryBuilder(IQueryFactory queryFactory)
		{
			if(queryFactory == null)
				throw new ArgumentNullException("queryFactory");

			this.queryFactory = queryFactory;
		}

		public TResult SingleOrDefault<TContext>(TContext context)
		{
			var query = queryFactory.Create<TContext, TResult>();

			return query.Execute(context);
		}

		public IEnumerable<TResult> Enumerable<TContext>(TContext context)
		{
			var query = queryFactory.Create<TContext, IEnumerable<TResult>>();

			return query.Execute(context);
		}
	}
}