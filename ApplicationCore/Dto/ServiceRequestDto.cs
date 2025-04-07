using MojeVlastniStranka.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Dto
{
	/// <summary>
	/// Request na žádost o konkrétní službu.
	/// </summary>
	public class ServiceRequestDto
	{
		[Required]
		public SubServiceEnum SubService
		{
			get;
			set;
		}

		[Required]
		[EmailAddress]
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

		[Required]
		public string Message
		{
			get;
			set;
		}
	}
}
