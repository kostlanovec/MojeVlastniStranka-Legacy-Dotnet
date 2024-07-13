namespace MojeVlastniStranka.Common.Dto
{
	public class BlogCategoryDto
	{
		/// <summary>
		/// Vrací nebo nastavuje Id blog kategorie.
		/// </summary>
		public Guid Id
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
