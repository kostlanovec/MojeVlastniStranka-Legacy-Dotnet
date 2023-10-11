using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MojeVlastniStranka.Admin.Pages
{
    public class _404Model : PageModel
    {
		[Route("/404/{code:int}")]
		public IActionResult HandleError(int code)
		{
			ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";
			return RedirectToPage("404");
		}
	}
}
