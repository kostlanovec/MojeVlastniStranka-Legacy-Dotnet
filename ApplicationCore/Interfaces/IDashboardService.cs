using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.Common.Enums;
using MojeVlastniStranka.Common.Models;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IDashboardService
    {
		Task<int> NumberOfContactForms();
		Task<int> NumberOfBlogPosts();
		Task<int> NumberOfServices();
		Task<List<GraphMainServicesModel>> NumberOfServicesPerMainServices();
    }
}
