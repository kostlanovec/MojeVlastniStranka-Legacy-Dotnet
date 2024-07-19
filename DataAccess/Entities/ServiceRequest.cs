using MojeVlastniStranka.Common.Enums;
namespace MojeVlastniStranka.DataAccess.Entities
{
	public class ServiceRequest: IEntities
	{
		protected ServiceRequest(){}

		/// <summary>
		/// Vrací nebo nastavuje Id Služby.
		/// </summary>
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje pod jakou hlavní službu se řadí.
		/// </summary>
		public MainServiceEnum MainService
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje pod jakou podslužbu se řadí.
		/// </summary>
		public SubServiceEnum SubService
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastauje email.
		/// </summary>
		public string Email
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje telefonní číslo.
		/// </summary>
		public string PhoneNumber
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje zprávu.
		/// </summary>
		public string Message
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje datum vytvoření.
		/// </summary>
		public DateTime CreatedAt
		{
			get;
			set;
		}
		public static ServiceRequest Create(MainServiceEnum mainService, SubServiceEnum subService, string email, string phoneNumber, string message, DateTime createdAt)
		{
			var serviceRequest = new ServiceRequest()
			{
                Id = Guid.NewGuid(),
                MainService = mainService,
				SubService = subService,
				Email = email,
				PhoneNumber = phoneNumber,
				Message = message,
				CreatedAt = createdAt
			};

			return serviceRequest;
		}
	}
}
