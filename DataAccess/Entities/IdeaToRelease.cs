using System.ComponentModel.DataAnnotations;

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
		public string Idea
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje datum přidání nápadu.
		/// </summary>
		public DateTime DatePosted
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="ContactForm"/> Vhodný pro uložení do databáze.
		/// </summary>
		public static IdeaToRelease Create(Guid id, string idea, DateTime datePosted)
		{
			var ideaToRelease = new IdeaToRelease()
			{
				Id = id,
				Idea = idea,
				DatePosted = datePosted
			};

			return ideaToRelease;
		}

	}
}