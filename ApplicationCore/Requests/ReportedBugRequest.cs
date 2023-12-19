using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class ReportedBugRequest
	{
		[Required(ErrorMessage = "Url is required.")]
		[Url]
		public string Url
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Bug is required.")]
		/// <summary>
		/// Vrací nebo nastavuje nápad na vylepšení.
		/// </summary>
		public string Bug
		{
			get;
			set;
		}
	}
}
