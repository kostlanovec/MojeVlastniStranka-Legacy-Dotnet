using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class NewsLetter: IEntities
	{
		protected NewsLetter() { }

		/// <summary>
		/// Vrací nebo nastavuje Id nápadu.
		/// </summary>
		public Guid Id
		{
			get;
			set;
		}

        /// <summary>
        /// Vrací nebo nastavuje email NewLetteru.
        /// </summary>
        [Column(TypeName = "nvarchar(1000)")]
        public string Email
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="NewsLetter"/> Vhodný pro uložení do databáze.
		/// </summary>
		public static NewsLetter Create(Guid id, string email)
		{
			var newsLetter = new NewsLetter()
			{
				Id = id,
				Email = email
			};

			return newsLetter;
		}
	}
}
