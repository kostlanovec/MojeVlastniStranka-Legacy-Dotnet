using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class NewsLetterRequest
	{
		/// <summary>
		/// Vrací nebo nastavuje subject emailů.
		/// </summary>
		[Required]
		public string Subject
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje html
		/// </summary>
		[Required]
		public string Body
		{
			get;
			set;
		}
	}
}
