using Hangfire.Dashboard;
using System.Diagnostics.CodeAnalysis;

namespace MojeVlastniStrankaFinanali.Web
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            // Povolit přístup jen přihlášeným uživatelům (případně lze ověřit roli Admin)
            return httpContext.User.Identity?.IsAuthenticated == true;
        }
    }
}
