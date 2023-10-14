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
    }
}
