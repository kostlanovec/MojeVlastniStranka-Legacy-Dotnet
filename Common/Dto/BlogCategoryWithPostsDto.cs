namespace MojeVlastniStranka.Common.Dto
{
	public class BlogCategoryWithPostsDto
	{
		public string Name
		{
			get;
			set;
		}

		public List<BlogPostSummary> BlogPosts
		{
			get;
			set;
		}
	}
}
