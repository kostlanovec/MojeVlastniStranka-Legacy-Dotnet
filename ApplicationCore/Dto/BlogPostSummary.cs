namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class BlogPostSummary
	{
		/// <summary>
		/// Vrací nebo nastavuje Id pro konkrétní blog.
		/// </summary>
		public Guid Id
		{
			get;
			set;
		}
		/// <summary>
		/// Vrací nebo nastavuje jméno blogu.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje popis blogu.
		/// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje cestu k obrázku potřebný pro hlavní blog.
		/// </summary>
		public string FilePath
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje url adresu pro blog příspěvek.
		/// </summary>
		public string Slug
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje čas, kdy byl blog příspěvek publikovaný.
		/// </summary>
		public DateTime TimePublic
		{
			get;
			set;
		}
	}
}
