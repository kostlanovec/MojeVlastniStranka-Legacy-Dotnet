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

		/// <summary>
		/// Přidání nového blog příspěvku.
		/// </summary>
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

		/// <summary>
		/// Získá blog příspěvky s popiskem a dalšími informace důležitý pro interakci.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetAllBlogPost()
		{
			var result = await dataManagementService.GetAllBlogPostSummaries();
			return result;
		}

		/// <summary>
		/// Získá tři blog příspěvky pro hlavní stránku.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetThreePost()
		{
			var result = await dataManagementService.GetThreePost();
			return result;
		}

		/// <summary>
		/// Získá blog příspěvek podle jeho id.
		/// </summary>
		public async Task<EditBlogPostDto> GetBlogPostById(int id)
		{
			return await dataManagementService.GetBlogPostById(id);
		}

		/// <summary>
		/// Získá list blog kategorií, které následně vykreslíme.
		/// </summary>
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

		/// <summary>
		/// Aktualizuje blog příspěvky.
		/// </summary>
		public async Task<FormProcessingResult> UpdateBlogPost(EditBlogPostRequest editBlogPostRequest)
		{
			var result = new FormProcessingResult();
			await dataManagementService.UpdateBlogPost(editBlogPostRequest);
			return result;
		}

		/// <summary>
		/// Získá filtrovaný blog příspěvky.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetFilteredBlogPosts(string searchString, string author,
			string keyword, int category, DateTime? fromDate, DateTime? toDate)
		{
			var allPosts = await dataManagementService.GetAllBlogPosts();
			var filteredPosts = allPosts;

			if (!string.IsNullOrEmpty(searchString))
			{
				filteredPosts = filteredPosts.Where(p =>
					p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
					p.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
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
				Slug = p.Slug,
				TimePublic = p.Date
			}).ToList();
		}

		/// <summary>
		/// Přidání nové blog kategorie.
		/// </summary>
		public async Task<FormProcessingResult> AddBlogCategory(string CategoryNameAdd)
		{
			var formProcessingResult = new FormProcessingResult();
			 await dataManagementService.AddBlogCategory(CategoryNameAdd);
			return formProcessingResult;

		}

		// to-do vyřešit, jak při odstranění blog kategorie přistupovat.
		public async Task<FormProcessingResult> DeleteBlogCategory(int IdBlogCategory){
			var formProcessingResult = new FormProcessingResult();
			await dataManagementService.DeleteBlogCategory(IdBlogCategory);
			return formProcessingResult;
		}

}
}
