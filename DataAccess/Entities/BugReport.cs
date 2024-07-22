using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class BugReport: IEntities
	{
		/// <summary>
		/// chráněný konsruktor.
		/// </summary>
		protected BugReport() { }

		/// <summary>
		/// Vrací nebo nastavuje Id bug reportu.
		/// </summary>
		[Key]
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje URL, na které byl bug nalezen.
		/// </summary>
		[Url]
        [Column(TypeName = "nvarchar(1000)")]
        public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje report o nalezeném bugu.
		/// </summary>
        [Column(TypeName = "nvarchar(1000)")]
        public string Report
		{
			get;
			set;
		}

        public static BugReport Create(string url, string report)
        {
            var bugReport = new BugReport()
            {
                Id = Guid.NewGuid(),
                Url = url,
                Report = report
            };

            return bugReport;
        }
    }
}
