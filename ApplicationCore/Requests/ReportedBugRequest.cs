using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class ReportedBugRequest
	{
		/// <summary>
		/// Vrací nebo nastavuje Url stránky, kde se chyba vyskytla.
		/// </summary>
		[Required(ErrorMessage = "Url je povinná položka.")]
		[Url]
		public string Url
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Chyba je povinná položka.")]
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
