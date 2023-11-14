using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class BugReport
	{
		public int Id
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
	}
}
