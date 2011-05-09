using System;
using System.Web.Mvc;
using Example.Queries.Contexts;
using Example.Queries.Impl;
using Example.Queries.Infrastructure;

namespace Example.Web.Controllers
{
	public class HomeController : QueryController
	{
		public HomeController(IQueryFactory queryFactory) : base(queryFactory)
		{
		}

		public ActionResult Index()
		{
			string message = Query<string>().SingleOrDefault(new GetWelcomeMessageQueryContext());
			ViewBag.Message = message;

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}