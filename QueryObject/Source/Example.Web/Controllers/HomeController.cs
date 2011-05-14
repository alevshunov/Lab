using System;
using System.Web.Mvc;
using Example.Queries.Contexts;
using Example.Queries.Infrastructure;
using Example.Queries.Results;

namespace Example.Web.Controllers
{
	public class HomeController : QueryController
	{
		public HomeController(IQueryFactory queryFactory) : base(queryFactory)
		{
		}

		public ActionResult Index()
		{
			int messageId = new Random().Next(1, 4);
			
			var context = new GetWelcomeMessageQueryContext {MessageId = messageId};
			Message message = Query<Message>().SingleOrDefault(context);
			ViewBag.Message = message.Text;

			var cachedMessageQueryContext = new GetCachedMessageQueryContext();
			var cachedMessage = Query<Message>().SingleOrDefault(cachedMessageQueryContext);
			ViewBag.CachedMessage = cachedMessage.Text;

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}