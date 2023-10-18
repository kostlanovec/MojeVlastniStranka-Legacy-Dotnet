using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
