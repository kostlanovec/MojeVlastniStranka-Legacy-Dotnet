namespace MojeVlastniStranka.DataAccess.Entities
{
	public class IdeaToRelease
	{
		protected IdeaToRelease() { }
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
#if DEBUG
		public static IdeaToRelease Create(int? id, string idea, DateTime datePosted)
		{
			var ideaToRelease = new IdeaToRelease()
			{
				Id = id,
				Idea = idea,
				DatePosted = datePosted
			};

			return ideaToRelease;
		}

#else
		public static IdeaToRelease Create(string idea, DateTime datePosted)
		{
			var ideaToRelease = new IdeaToRelease()
			{
				Idea = idea,
				DatePosted = datePosted
			};

			return ideaToRelease;
		}
#endif
	}
}