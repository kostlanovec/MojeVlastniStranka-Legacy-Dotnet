using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MojeVlastniStranka.Admin.Pages
{
    public class StatusCodeModel : PageModel
    {
        public int Code { get; set; }
        public void OnGet(int code)
        {
            Code = code;
        }
    }
}
