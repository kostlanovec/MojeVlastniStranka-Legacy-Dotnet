using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Common.Enums;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IServicesOfferedService
    {
		Task AddServiceRequestAsync(ServiceRequestDto serviceRequestDto);
		List<ServiceRequest> getAllServicesRequests();
    }
}
