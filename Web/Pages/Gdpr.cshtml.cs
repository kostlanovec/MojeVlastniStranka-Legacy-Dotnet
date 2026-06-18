#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.OutputCaching;

namespace MojeVlastniStranka.Web.Pages
{
	[OutputCache(Duration = int.MaxValue)]
	public class GdprModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
