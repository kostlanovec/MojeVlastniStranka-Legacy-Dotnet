using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Controllers
{
    [Route("[controller]")]
	public class ContactFormController : Controller
	{
		private readonly DataContext context;
		public NotificationService Notification;
		public ContactFormController(DataContext context, NotificationService notification)
		{
			this.context = context;
			this.Notification = notification;
		}

		[HttpPost]
		// todo Přidat možnost, jakou zemi skrz telefonní číslo máme
		public async Task<IActionResult> SubmitContactForm(ContactFormularRequest contactform)
		{
			ContactFormService contactFormService = new ContactFormService(context, Notification);
			var result = await contactFormService.FormProcessing(contactform);

			if (result.IsSuccess)
			{
				return Json(new { success = true, message = "Formulář byl úspěšně odeslán." });
			}
			else
			{
				var errors = result.Errors.Select(error => new {
					memberName = error.MemberNames.FirstOrDefault() ?? "",
					errorMessage = error.ErrorMessage
				}).ToList();

				return Json(new { success = false, errors });
			}
		}
	}
}
