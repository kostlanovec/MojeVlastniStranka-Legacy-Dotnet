using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.OutputCaching;

namespace MojeVlastniStrankaFinal.Web.Pages
{
	[OutputCache(Duration = int.MaxValue)]
	public class OchranaSoukromiModel : PageModel
	{
	}
}
