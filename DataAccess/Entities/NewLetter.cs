
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class NewsLetter
	{
		protected NewsLetter() { }

		/// <summary>
		/// Vrací nebo nastavuje Id nápadu.
		/// </summary>
		public int? Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje email NewLetteru.
		/// </summary>
		public string Email
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="NewsLetter"/> Vhodný pro uložení do databáze.
		/// </summary>
#if DEBUG
		public static NewsLetter Create(int? id, string email)
		{
			var newsLetter = new NewsLetter()
			{
				Id = id,
				Email = email
			};

			return newsLetter;
		}

#else
		public static NewsLetter Create(string email)
		{
			var newsLetter = new NewLetter()
			{
				Email = email
			};

			return newsLetter;
		}
#endif
	}
}
