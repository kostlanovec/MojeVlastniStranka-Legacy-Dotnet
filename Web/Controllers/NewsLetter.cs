using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.ApplicationCore.Services;

namespace MojeVlastniStranka.Web.Controllers
{
	public class NewsLetter : BaseController
	{
		private readonly MailService mailService;

		public IActionResult Index()
		{
			return View();
		}
	}
}
