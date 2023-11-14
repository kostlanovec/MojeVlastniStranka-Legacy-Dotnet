using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage.Development
{
    public class IdeaToReleaseModel : PageModel
    {
        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("ahoj");
            return Page();
        }

    }
}
