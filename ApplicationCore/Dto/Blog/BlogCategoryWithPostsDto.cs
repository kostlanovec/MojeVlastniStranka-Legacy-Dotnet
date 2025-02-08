namespace MojeVlastniStranka.ApplicationCore.Dto.Blog
{
	public class BlogCategoryWithPostsDto
	{
		/// <summary>
		/// Vrací nebo nastavuje název blogů.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje seznam blog příspěvků.
		/// </summary>
		public List<BlogPostSummary> BlogPosts
		{
			get;
			set;
		}
	}
}
