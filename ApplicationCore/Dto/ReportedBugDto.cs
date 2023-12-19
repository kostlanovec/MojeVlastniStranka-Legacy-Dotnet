namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class ReportedBugDto
	{
		public int? Id
		{
			get;
			set;
		}
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
