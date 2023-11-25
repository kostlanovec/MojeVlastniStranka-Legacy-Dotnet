using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class ReportedBugRequest
	{
		[Url]
		public string Url
		{
			get;
			set;
		}

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
