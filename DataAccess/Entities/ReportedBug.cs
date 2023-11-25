using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class ReportedBug
	{
		protected ReportedBug() { }
		/// <summary>
		/// Vrací nebo nastavuje Id nápadu.
		/// </summary>
		public int? Id
		{
			get;
			set;
		}

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

		/// <summary>
		/// Vrací nebo nastavuje datum přidání nápadu.
		/// </summary>
		public DateTime DatePosted
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="ContactForm"/> Vhodný pro uložení do databáze.
		/// </summary>
#if DEBUG
		public static ReportedBug Create(int? id, string url, string bug, DateTime datePosted)
		{
			var reportedBug = new ReportedBug()
			{
				Id = id,
				Url = url,
				Bug = bug,
				DatePosted = datePosted
			};

			return reportedBug;
		}

#else
		public static ReportedBug Create( string url, string bug, DateTime datePosted)
		{
			var reportedBug = new ReportedBug()
			{
				Url = url,
				Bug = bug,
				DatePosted = datePosted
			};

			return reportedBug;
		}
#endif
	}
}
