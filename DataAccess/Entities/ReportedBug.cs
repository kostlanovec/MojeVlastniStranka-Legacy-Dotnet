using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class ReportedBug: IEntities
	{
		protected ReportedBug() { }
		/// <summary>
		/// Vrací nebo nastavuje Id nápadu.
		/// </summary>
		public Guid Id
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

		public static ReportedBug Create(Guid id, string url, string bug, DateTime datePosted)
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
	}
}
