using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace CoreBB.Web.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult Index()
		{
			var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
			ViewData["StatusCode"] = HttpContext.Response.StatusCode;
			ViewData["Message"] = exception.Error.Message;
			ViewData["StackTrace"] = exception.Error.StackTrace;

			return View();
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
