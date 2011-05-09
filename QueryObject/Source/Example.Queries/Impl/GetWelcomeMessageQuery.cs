using System;
using Example.Queries.Infrastructure;

namespace Example.Queries.Impl
{
	public class GetWelcomeMessageQuery : IQuery<GetWelcomeMessageQueryContext, string>
	{
		public string Execute(GetWelcomeMessageQueryContext context)
		{
			return "Welcome to ASP.NET MVC!";
		}
	}

	public class GetWelcomeMessageQueryContext
	{
	}
}