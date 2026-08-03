using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Common.Enums;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class ServicesOfferedService : IServicesOfferedService
	{
		private readonly DataContext context;

		public ServicesOfferedService(DataContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Ukládá službu do databáze.
		/// </summary>
		public async Task AddServiceRequestAsync(ServiceRequestDto serviceRequestDto)
		{
			var serviceRequest = ServiceRequest.Create(
				MainServiceEnum.Website,
				serviceRequestDto.SubService,
				serviceRequestDto.Email,
				serviceRequestDto.PhoneNumber,
				serviceRequestDto.Message,
				DateTime.UtcNow
);
			context.ServiceRequests.Add(serviceRequest);
			await context.SaveChangesAsync();
		}

		/// <summary>
		/// Vrací list služeb.
		/// </summary>
		public List<ServiceRequest> getAllServicesRequests()
		{
			return context.ServiceRequests.AsNoTracking().ToList();
		}
	}
}
