#nullable disable
using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.ApplicationCore.Services;

namespace MojeVlastniStranka.Web.Controllers
{
	public class NewsletterController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
