using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Services
{
    public class BlogService
    {
        private readonly DataManagementService dataManagementService;

        public BlogService(DataContext context)
        {
            this.dataManagementService = new DataManagementService(context);
        }

        public async Task<FormProcessingResult> AddBlogPost(BlogPostRequest blogPostRequst)
        {
            var result = new FormProcessingResult();
            var validationResults = blogPostRequst.Validate(new ValidationContext(blogPostRequst)).ToList();

            if (validationResults.Any())
            {
                result.IsSuccess = false;
                result.Errors = validationResults;
                return result;
            }

            await dataManagementService.AddBlogPost(blogPostRequst);
            result.IsSuccess = true;
            return result;
        }

		public async Task<List<BlogPostSummary>> GetAllBlogPost()
        {
            var result = await dataManagementService.GetAllBlogPostSummaries();
            return result;
        }

		public async Task<List<BlogPostSummary>> GetThreePost()
		{
			var result = await dataManagementService.GetThreePost();
			return result;
		}

        public async Task<EditBlogPostDto> GetBlogPostById(int id)
        {
            return await dataManagementService.GetBlogPostById(id);
        }

        public async Task<List<BlogCategoryDto>> GetAllCategoriesTask()
        {
            var blogCategory = await dataManagementService.GetAllBlogCategory();

            var blogCategoryList = blogCategory.Select(e => new BlogCategoryDto()
            {
                Id = e.Id,
                Name = e.Name,
            }).ToList();

            return blogCategoryList;
        }
        public async Task<FormProcessingResult> UpdateBlogPost(EditBlogPostRequest editBlogPostRequest)
        {
	        var result = new FormProcessingResult();
	        await dataManagementService.UpdateBlogPost(editBlogPostRequest);
            return result;
        }

		public async Task<List<BlogPostSummary>> GetFilteredBlogPosts(string searchString, string author, string keyword, int category, DateTime? fromDate, DateTime? toDate)
		{
			var allPosts = await dataManagementService.GetAllBlogPosts();
			var filteredPosts = allPosts;

			if (!string.IsNullOrEmpty(searchString))
			{
				filteredPosts = filteredPosts.Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || p.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			if (!string.IsNullOrEmpty(author))
			{
				filteredPosts = filteredPosts.Where(p => p.Author == author).ToList();
			}

			if (!string.IsNullOrEmpty(keyword))
			{
				filteredPosts = filteredPosts.Where(p => p.Keywords == keyword).ToList();
			}

			if (category != 0)
			{
				filteredPosts = filteredPosts.Where(p => p.BlogCategoryId == category).ToList();
			}

			if (fromDate.HasValue)
			{
				filteredPosts = filteredPosts.Where(p => p.Date >= fromDate.Value).ToList();
			}

			if (toDate.HasValue)
			{
				filteredPosts = filteredPosts.Where(p => p.Date <= toDate.Value).ToList();
			}

			return filteredPosts.Select(p => new BlogPostSummary
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				FilePath = p.ImagePath,
				Slug = p.Slug
			}).ToList();
		}

	}
}
