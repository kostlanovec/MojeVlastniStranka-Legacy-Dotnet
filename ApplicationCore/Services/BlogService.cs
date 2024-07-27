using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
    public class BlogService
	{
		private readonly DataContext context;

		public BlogService(DataContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Přidání nového blog příspěvku.
		/// </summary>
		public async Task<ResponseViewModel> AddBlogPost(BlogPostRequest blogPostRequest)
		{
			var response = new ResponseViewModel();

			if (string.IsNullOrEmpty(blogPostRequest.Description) ||
				string.IsNullOrEmpty(blogPostRequest.Content) ||
				string.IsNullOrEmpty(blogPostRequest.Title) ||
				string.IsNullOrEmpty(blogPostRequest.Author) ||
				string.IsNullOrEmpty(blogPostRequest.Keywords) ||
				string.IsNullOrEmpty(blogPostRequest.Name) ||
				string.IsNullOrEmpty(blogPostRequest.Slug))
			{
				response.IsSuccess = false;
				response.Errors.Add("Všechna políčka jsou povinná krom přidání blog kategorie.");
				return response;
			}

			bool slugExists = await context.BlogPosts.AnyAsync(bp => bp.Slug == blogPostRequest.Slug);
			if (slugExists)
			{
				response.IsSuccess = false;
				response.Errors.Add($"Blog příspěvek se slugem: '{blogPostRequest.Slug}' ¨již existuje.");
			}

			bool nameExists = await context.BlogPosts.AnyAsync(bp => bp.Name == blogPostRequest.Name);
			if (nameExists)
			{
				response.IsSuccess = false;
				response.Errors.Add($"Blog příspěvek s tímto názvem: '{blogPostRequest.Name}' již existuje..");
			}

			if (!response.IsSuccess)
			{
				return response;
			}

			string imagePath = await UploadImageAsync(blogPostRequest.FileUpload);

			var blogPost = BlogPost.Create(
				blogPostRequest.Description,
				blogPostRequest.Content,
				blogPostRequest.Title,
				blogPostRequest.Author,
				blogPostRequest.Keywords,
				blogPostRequest.BlogCategoryId,
				blogPostRequest.Name,
				imagePath,
				blogPostRequest.Slug,
				// todo: udělat publikování v určitou dobu
				DateTime.Now
			);

			context.BlogPosts.Add(blogPost);
			await context.SaveChangesAsync();

			response.IsSuccess = true;
			response.SuccessMessage = "Blog příspěvek byl úspěšně přidaný.";
			return response;
		}

		/// <summary>
		/// Získá všechny blog kategorie s příspěvky.
		/// </summary>
		public async Task<List<BlogCategoryWithPostsDto>> GetAllCategoriesWithPosts()
		{
			var result = await context.BlogCategories
				.Include(bc => bc.BlogPosts)
				.Select(bc => new BlogCategoryWithPostsDto
				{
					Name = bc.Name,
					BlogPosts = bc.BlogPosts.Select(bp => new BlogPostSummary
					{
						Id = bp.Id,
						Name = bp.Name,
						Description = bp.Description,
						FilePath = bp.ImagePath,
						Slug = bp.Slug,
						TimePublic = bp.Date
					}).ToList()
				})
				.Where(predicate => predicate.BlogPosts.Any())
				.ToListAsync();
			return result;
		}

		/// <summary>
		/// Získá všechny blog kategorie s příspěvky a 4 novějšími příspěvky.
		/// </summary>
		public async Task<List<BlogCategoryWithPostsDto>> GetAllCategoriesPostsWitFourNewerPosts()
		{
			var blogcategorylist = await GetAllCategoriesWithPosts();
			var fourNewerPosts = await GetFourNewerPosts();

			var specialCategory = new BlogCategoryWithPostsDto
			{
				Name = "Nejnovější příspěvky",
				BlogPosts = fourNewerPosts
			};

            blogcategorylist.Insert(0, specialCategory);

            return blogcategorylist;
		}

		/// <summary>
		/// Získá 4 blog príspěvky.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetFourNewerPosts()
		{
			var result = await context.BlogPosts
				.OrderByDescending(bp => bp.Date)
				.Take(4)
				.Select(bp => new BlogPostSummary
				{
					Id = bp.Id,
					Name = bp.Name,
					Description = bp.Description,
					FilePath = bp.ImagePath,
					Slug = bp.Slug,
					TimePublic = bp.Date
				})
				.ToListAsync();

			return result;
		}

		/// <summary>
		/// Získá blog příspěvky s popiskem a dalšími informace důležitý pro interakci.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetAllBlogPost()
		{
			var result = await context.BlogPosts
				.Select(bp => new BlogPostSummary
				{
					Id = bp.Id,
					Name = bp.Name,
					Description = bp.Description,
					FilePath = bp.ImagePath,
					Slug = bp.Slug,
					TimePublic = bp.Date
				})

				.ToListAsync();
			return result;
		}

		/// <summary>
		/// Získá všechny blog příspěvky s id 2 neboli získá všechny projekty.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetAllProject()
		{
			var result = await context.BlogPosts
				.Select(bp => new BlogPostSummary
				{
					Id = bp.Id,
					Name = bp.Name,
					Description = bp.Description,
					FilePath = bp.ImagePath,
					Slug = bp.Slug,
					TimePublic = bp.Date
				})
				.ToListAsync();
			return result;
		}

		/// <summary>
		/// Získá tři blog příspěvky pro hlavní stránku.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetThreePost()
		{
			var result = await context.BlogPosts
				.OrderBy(bp => bp.Id)
				.Take(3)
				.Select(bp => new BlogPostSummary
				{
					Id = bp.Id,
					Name = bp.Name,
					Description = bp.Description,
					FilePath = bp.ImagePath,
					Slug = bp.Slug,
				})
				.ToListAsync();
			return result;
		}

		/// <summary>
		/// Získá blog příspěvek podle jeho id.
		/// </summary>
		public async Task<EditBlogPostDto> GetBlogPostById(Guid id)
		{
			var existingBlogPost = await context.BlogPosts
				.SingleOrDefaultAsync(bp => bp.Id == id);

			if (existingBlogPost == null)
			{
				return null;
			}

			var editBlogPostDto = new EditBlogPostDto
			{
				Id = existingBlogPost.Id,
				Name = existingBlogPost.Name,
				Slug = existingBlogPost.Slug,
				Description = existingBlogPost.Description,
				Content = existingBlogPost.Content,
				Title = existingBlogPost.Title,
				Author = existingBlogPost.Author,
				Keywords = existingBlogPost.Keywords,
				BlogCategoryId = existingBlogPost.BlogCategoryId,
				blogCategory = existingBlogPost.BlogCategory,
				FileUpload = existingBlogPost.ImagePath
			};
			return editBlogPostDto;
		}

		/// <summary>
		/// Získá list blog kategorií, které následně vykreslíme.
		/// </summary>
		public async Task<List<BlogCategoryDto>> GetAllCategoriesTask()
		{
			var blogCategory = await context.BlogCategories.ToListAsync();

			var blogCategoryList = blogCategory.Select(e => new BlogCategoryDto()
			{
				Id = e.Id,
				Name = e.Name,
			}).ToList();

			return blogCategoryList;
		}

		// <summary>
		/// Aktualizuje blog příspěvky.
		/// </summary>
		public async Task<ResponseViewModel> UpdateBlogPost(EditBlogPostRequest editBlogPostRequest)
		{
			var response = new ResponseViewModel();
			var existingBlogPost = await context.BlogPosts.SingleOrDefaultAsync(bp => bp.Id == editBlogPostRequest.Id);

			if (existingBlogPost == null)
			{
				response.IsSuccess = false;
				response.Errors.Add("Blog příspěvek nebyl nalezen.");
				return response;
			}

			existingBlogPost.Description = editBlogPostRequest.Description;
			existingBlogPost.Content = editBlogPostRequest.Content;
			existingBlogPost.Title = editBlogPostRequest.Title;
			existingBlogPost.Author = editBlogPostRequest.Author;
			existingBlogPost.Keywords = editBlogPostRequest.Keywords;
			existingBlogPost.BlogCategoryId = editBlogPostRequest.BlogCategoryId;
			existingBlogPost.Name = editBlogPostRequest.Name;

			if (editBlogPostRequest.FileUpload != null)
			{
				existingBlogPost.ImagePath = await UploadImageAsync(editBlogPostRequest.FileUpload);
			}

			await context.SaveChangesAsync();

			response.IsSuccess = true;
			response.SuccessMessage = "Blog příspěvek byl úspěšně aktualizován.";
			return response;
		}


		/// <summary>
		/// Získá filtrovaný blog příspěvky.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetFilteredBlogPosts(string searchString, string author,
			string keyword, Guid category, DateTime? fromDate, DateTime? toDate)
		{
			var allPosts = await context.BlogPosts.ToListAsync(); ;
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

			if (category != Guid.Empty)
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
		public async Task<ResponseViewModel> AddBlogCategory(string CategoryNameAdd)
		{
			var response = new ResponseViewModel();
			var blogCategoryExist = await context.BlogCategories.SingleOrDefaultAsync(bp => bp.Name == CategoryNameAdd);

			if (blogCategoryExist != null)
			{
				response.IsSuccess = false;
				response.Errors.Add("Kategorie s tímto názvem již existuje.");
				return response;
			}

			var newCategory = BlogCategory.Create(CategoryNameAdd);
			context.BlogCategories.Add(newCategory);
			await context.SaveChangesAsync();

			response.IsSuccess = true;
			response.SuccessMessage = "Kategorie byla úspěšně přidána.";
			return response;
		}

		/// <summary>
		/// Smazání blog kategorie podle jeho id.
		/// </summary>
		/// <param name="BlogCategoryId">Smazání blog kategorie.</param>
		public async Task<ResponseViewModel> DeleteBlogCategory(Guid BlogCategoryId)
		{
			var response = new ResponseViewModel();
			var existingBlogCategory = await context.BlogCategories.SingleOrDefaultAsync(bp => bp.Id == BlogCategoryId);

			if (existingBlogCategory == null)
			{
				response.IsSuccess = false;
				response.Errors.Add("Kategorie nebyla nalezena.");
				return response;
			}

			var existingAllBlogWithDeleteBlogCategory = context.BlogPosts.Where(bp => bp.BlogCategoryId == BlogCategoryId);

			if (existingAllBlogWithDeleteBlogCategory.Any())
			{
				foreach (var blogPost in existingAllBlogWithDeleteBlogCategory)
				{
					blogPost.BlogCategoryId = null;
				}
			}

			context.Remove(existingBlogCategory);
			await context.SaveChangesAsync();

			response.IsSuccess = true;
			response.SuccessMessage = "Kategorie byla úspěšně smazána.";
			return response;
		}

		/// <summary>
		/// Smaže blog příspěvek podle jeho Id.
		/// </summary>
		public async Task<ResponseViewModel> DeleteBlogPost(Guid BlogId)
		{
			var response = new ResponseViewModel();
			var existingBlog = await context.BlogPosts.SingleOrDefaultAsync(bp => bp.Id == BlogId);

			if (existingBlog == null)
			{
				response.IsSuccess = false;
				response.Errors.Add("Blog příspěvek nebyl nalezen.");
				return response;
			}

			context.Remove(existingBlog);
			await context.SaveChangesAsync();

			response.IsSuccess = true;
			response.SuccessMessage = "Blog příspěvek byl úspěšně smazán.";
			return response;
		}

		/// <summary>
		/// Uloží obrázek do určeného úložiště.
		/// </summary>
		private async Task<string> UploadImageAsync(IFormFile file)
		{
			var currentDirectory = Directory.GetCurrentDirectory();
			var uploadsDirectory = Path.Combine(currentDirectory, "wwwroot", "images", "blog");
			var filePath = Path.Combine(uploadsDirectory, file.FileName);

			if (File.Exists(filePath))
			{
				return ("/images/blog/" + file.FileName);
			}

			if (!Directory.Exists(uploadsDirectory))
			{
				Directory.CreateDirectory(uploadsDirectory);
			}

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return ("/images/blog/" + file.FileName);
		}

		public async Task<List<BlogPostSummary>> SearchBlogPostsAsync(string query)
		{
			// Implementujte logiku vyhledávání, např. dotazování databáze podle klíčových slov
			var results = await context.BlogPosts
				.Where(p => p.Name.Contains(query) || p.Description.Contains(query))
				.Select(p => new BlogPostSummary
				{
					Name = p.Name,
					Slug = p.Slug,
					FilePath = p.ImagePath,
					Description = p.Description
				})
				.ToListAsync();

			return results;
		}

	}
}