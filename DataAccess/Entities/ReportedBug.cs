using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "text")]
        public string Url
		{
			get;
			set;
		}

        /// <summary>
        /// Vrací nebo nastavuje nápad na vylepšení.
        /// </summary>
        [Column(TypeName = "text")]
        public string Bug
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje datum přidání nápadu.
		/// </summary>
		[Column(TypeName = "timestamp")]
		public DateTime DatePosted
		{
			get;
			set;
		}

		public static ReportedBug Create(string url, string bug, DateTime datePosted)
		{
			var reportedBug = new ReportedBug()
			{
                Id = Guid.NewGuid(),
                Url = url,
				Bug = bug,
				DatePosted = datePosted
			};

			return reportedBug;
		}
	}
}
