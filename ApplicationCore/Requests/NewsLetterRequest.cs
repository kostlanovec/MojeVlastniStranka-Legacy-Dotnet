using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class NewsLetterRequest
	{
		public string Subject
		{
			get;
			set;
		}

		public string Body
		{
			get;
			set;
		}
	}
}
