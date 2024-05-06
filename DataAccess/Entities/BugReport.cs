using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class BugReport: IEntities
	{
		[Key]
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

		public string Report
		{
			get;
			set;
		}

        public static BugReport Create(Guid id, string url, string report)
        {
            var bugReport = new BugReport()
            {
                Id = id,
                Url = url,
                Report = report
            };

            return bugReport;
        }
    }
}
