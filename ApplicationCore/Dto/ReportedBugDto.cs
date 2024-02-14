namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class ReportedBugDto
	{
		/// <summary>
		/// Vrací nebo nastavuje Id nahlášení chyby.
		/// </summary>
		public int? Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje url nahlášené chyby.
		/// </summary>
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
