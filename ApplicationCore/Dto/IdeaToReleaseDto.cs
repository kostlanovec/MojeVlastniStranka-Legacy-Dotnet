using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class IdeaToReleaseDto
	{
		/// <summary>
		/// Vrací nebo nastavuje Id nápadu.
		/// </summary>
		public int? Id
		{
			get; 
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje nápad na vylepšení.
		/// </summary>
		public string Idea
		{
			get;
			set;
		}
	}
}
