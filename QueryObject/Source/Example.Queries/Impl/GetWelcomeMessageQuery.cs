using System;
using System.Collections.Generic;
using Example.Queries.Contexts;
using Example.Queries.Infrastructure;
using Example.Queries.Results;

namespace Example.Queries.Impl
{
	public class GetWelcomeMessageQuery : IQuery<GetWelcomeMessageQueryContext, Message>
	{
		//Collection is just your data storage. You can inject here EF's DataContext or NHibernate's ISession
		private readonly Dictionary<int, Message> collection;

		public GetWelcomeMessageQuery()
		{
			var message1 = new Message(1, "Hello, world!");
			var message2 = new Message(2, "Welcome to ASP.NET MVC!");
			var message3 = new Message(3, "Hi, dude!");

			collection = new Dictionary<int, Message>
			             	{
			             		{message1.Id, message1},
			             		{message2.Id, message2},
			             		{message3.Id, message3}
			             	};
		}

		public Message Execute(GetWelcomeMessageQueryContext context)
		{
			if(collection.ContainsKey(context.MessageId))
				return collection[context.MessageId];

			return null;
		}
	}
}