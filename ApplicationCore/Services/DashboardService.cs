using MojeVlastniStranka.DataAccess;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.Common.Enums;
using MojeVlastniStranka.Common.Models;

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

		/// <summary>
		/// Vrací nebo nastavuje počet požadavků na službu.
		/// </summary>
		public async Task<int> NumberOfServices()
		{
			return await context.ServiceRequests.CountAsync();
		}

		// todo jak udělat, získavání služeb
		public async Task<List<GraphMainServices>> NumberOfServicesPerMainServices()
		{
			var result = new List<GraphMainServices>();
			// dynamicky získávat hlavní služby
			foreach (MainServiceEnum mainService in Enum.GetValues(typeof(MainServiceEnum)))
			{
				int servicesRequestNumber = context.ServiceRequests.Where(n => n.MainService == mainService).Count();

				var GraphMainServices = new GraphMainServices()
				{
					NameOfService = mainService.ToString(),
					NumberOfServices = servicesRequestNumber
				};
				result.Add(GraphMainServices);
			}
			return result;
		}
	}
}