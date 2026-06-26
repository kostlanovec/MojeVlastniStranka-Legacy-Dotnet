using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class ContactFormularDto
	{
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

		/// <summary>
		/// Vrací nebo nastavuje, kdy byl formulář odeslaný.
		/// </summary>
		public DateTime SendTime
		{
			get;
			set;
		}
	}
}
