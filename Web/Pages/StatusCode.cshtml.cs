#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MojeVlastniStrankaFinal.Web.Pages
{
	public class StatusCodeModel : PageModel
	{
		public int Code
		{
			get;
			set;
		}

		public void OnGet(int code)
		{
			Code = code;
		}
	}
}
