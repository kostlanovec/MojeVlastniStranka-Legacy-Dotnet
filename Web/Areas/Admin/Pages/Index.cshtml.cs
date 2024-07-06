using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Account.Manage
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly DataContext context;
        private readonly DashboardService dashboardService;

        public IndexModel(DataContext context, DashboardService dashboardService)
        {
            this.context = context;
            this.dashboardService = dashboardService;
        }

        public int NumberOfContactForms
        {
            get;
            set;
        }

        public int NumberOfBlogPosts
        {
            get;
            set;
        }

        public async Task OnGetAsync()
        {
            NumberOfContactForms = await dashboardService.NumberOfContactForms();
            NumberOfBlogPosts = await dashboardService.NumberOfBlogPosts();
        }
    }
}
