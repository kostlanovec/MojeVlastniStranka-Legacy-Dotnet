namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class BlogCategoryDto
	{
		/// <summary>
		/// Vrací nebo nastavuje Id blog kategorie.
		/// </summary>
		public int? Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje jméno blog kategorie.
		/// </summary>
		public string Name
		{
			get;
			set;
		}
	}
}
