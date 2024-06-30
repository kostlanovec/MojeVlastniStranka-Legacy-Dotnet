using MojeVlastniStranka.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MojeVlastniStranka.ApplicationCore.Services
{
    public class DashboardService
    {
        private readonly DataContext context;

        public DashboardService(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Získá celkový počet poslaných formulářů.
        /// </summary>
        public async Task<int> NumberOfContactForms()
        {
            return await context.ContactForms.CountAsync();
        }

        /// <summary>
        /// Získá celkový počet blog příspěvků.
        /// </summary>
        public async Task<int> NumberOfBlogPosts()
        {
            return await context.BlogPosts.CountAsync();
        }
    }
}
