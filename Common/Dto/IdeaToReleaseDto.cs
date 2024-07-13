namespace MojeVlastniStranka.Common.Dto
{
	public class IdeaToReleaseDto
	{
		/// <summary>
		/// Vrací nebo nastavuje Id nápadu.
		/// </summary>
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
	}
}
