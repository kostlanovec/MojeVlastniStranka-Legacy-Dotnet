using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class BlogPostSummary
	{
		public int? Id
		{
			get;
			set;
		}
		public string Slug
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string FilePath
		{
			get;
			set;
		}
	}
}
