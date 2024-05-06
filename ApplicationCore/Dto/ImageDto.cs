namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class ImageDto
	{
		/// <summary>
		/// Id obrázku
		/// </summary>
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Název souboru
		/// </summary>
		public string FileName
		{
			get;
			set;
		}

		/// <summary>
		/// Popis obrázku neboli alt atribut.
		/// </summary>
		public string Description
		{
			get;
			set;
		}
	}
}
