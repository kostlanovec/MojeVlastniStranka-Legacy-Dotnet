using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages
{
    [Authorize]
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
