using MojeVlastniStranka.Common.Enums;

namespace MojeVlastniStranka.ApplicationCore.Dto.Project
{
	public class ProjectSummaryDto
	{
		/// <summary>
		/// Vrací nebo nastavuje identifikátor projektu.
		/// </summary>
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje jméno projektu.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje slug projektu.
		/// </summary>
		public string Slug
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje popisek projektu.
		/// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje cestu k obrázku.
		/// </summary>
		public string ImagePath
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje datum zveřejnění.
		/// </summary>
		public DateTime PublicDate
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje status projektu.
		/// </summary>
		public ProjectStatusEnum ProjectStatus
		{
			get;
			set;
		}
	}
}
