using System;
using System.Web.Mvc;
using Hangfire;
using HangfireNinjectProject.Mock;

namespace HangfireNinjectProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly IMockService _mockService;

		public HomeController(IMockService mockService)
		{
			_mockService = mockService;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult FireAndForget()
		{
			return View();
		}

		[HttpPost]
		public ActionResult FireAndForget(string parametro)
		{
			BackgroundJob.Enqueue(() => _mockService.DoSomethingDelayed(new MockObject { FakeProperty = parametro }));
			return View("Index");
		}

		public ActionResult FireAndForgetBigger()
		{
			return View();
		}

		[HttpPost]
		public ActionResult FireAndForgetBigger(string parametro)
		{
			BackgroundJob.Enqueue(() => _mockService.DoSomethingBigger(new MockObject { FakeProperty = parametro }));
			return View("Index");
		}

		public ActionResult RecurringJob()
		{
			return View();
		}

		[HttpPost]
		public ActionResult RecurringJob(string parametro)
		{
			Hangfire.RecurringJob.AddOrUpdate(parametro, () => _mockService.DoSomethingBigger(new MockObject { FakeProperty = parametro }), Cron.Minutely);
			return View("Index");
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}