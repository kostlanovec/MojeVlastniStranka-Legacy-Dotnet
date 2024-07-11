using MojeVlastniStranka.Common.Enums;
namespace MojeVlastniStranka.DataAccess.Entities
{
	public class ServiceRequest: IEntities
	{
		protected ServiceRequest()
		{
		}
		public Guid Id
		{
			get;
			set;
		}

		public MainServiceEnum MainService
		{
			get;
			set;
		}

		public SubServiceEnum subService
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		public string PhoneNumber
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}

		public DateTime CreatedAt
		{
			get;
			set;
		}

		public static ServiceRequest Create(Guid id, MainServiceEnum mainService, SubServiceEnum subService, string email, string phoneNumber, string message, DateTime createdAt)
		{
			var serviceRequest = new ServiceRequest()
			{
				Id = id,
				MainService = mainService,
				subService = subService,
				Email = email,
				PhoneNumber = phoneNumber,
				Message = message,
				CreatedAt = createdAt
			};

			return serviceRequest;
		}
	}
}
