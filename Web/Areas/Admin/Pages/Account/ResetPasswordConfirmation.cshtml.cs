#nullable disable
#nullable disable
#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MojeVlastniStranka.Web.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class ResetPasswordConfirmationModel : PageModel
	{
		public void OnGet()
		{
		}
	}
}