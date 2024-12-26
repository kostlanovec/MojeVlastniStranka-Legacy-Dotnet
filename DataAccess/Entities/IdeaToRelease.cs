using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class IdeaToRelease: IEntities
	{
		protected IdeaToRelease() { }

		/// <summary>
		/// Vrací nebo nastavuje Id nápadu.
		/// </summary>
		[Key]
		public Guid Id
		{
			get;
			set;
		}

        /// <summary>
        /// Vrací nebo nastavuje nápad na vylepšení.
        /// </summary>
        [Column(TypeName = "text")]
        public string Idea
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje datum přidání nápadu.
		/// </summary>
		[Column(TypeName = "timestamp")]
		public DateTime DatePosted
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="ContactForm"/> Vhodný pro uložení do databáze.
		/// </summary>
		public static IdeaToRelease Create(string idea, DateTime datePosted)
		{
			var ideaToRelease = new IdeaToRelease()
			{
				Id = Guid.NewGuid(),
				Idea = idea,
				DatePosted = datePosted
			};

			return ideaToRelease;
		}

	}
}