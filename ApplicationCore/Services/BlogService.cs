using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class BlogService : IBlogService
	{
		private readonly DataContext context;
		private readonly IImageService imageService;

		public BlogService(DataContext context, IImageService imageService)
		{
			this.context = context;
			this.imageService = imageService;
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

			string imagePath = await imageService.UploadImageAsync(blogPostRequest.FileUpload, "blog");

			var sanitizer = new Ganss.Xss.HtmlSanitizer();

			var blogPost = BlogPost.Create(
				blogPostRequest.Description,
				sanitizer.Sanitize(blogPostRequest.Content ?? ""),
				blogPostRequest.Title,
				blogPostRequest.Author,
				blogPostRequest.Keywords,
				blogPostRequest.BlogCategoryId,
				blogPostRequest.Name,
				imagePath,
				blogPostRequest.Slug,
				blogPostRequest.DatePublic == default ? DateTime.Now : blogPostRequest.DatePublic,
				blogPostRequest.NameEn,
				blogPostRequest.DescriptionEn,
				sanitizer.Sanitize(blogPostRequest.ContentEn ?? ""),
				blogPostRequest.TitleEn,
				blogPostRequest.KeywordsEn
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
				.AsNoTracking()
				.Include(bc => bc.BlogPosts)
				.Where(bc => bc.BlogPosts.Any())
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
						TimePublic = bp.Date,
					NameEn = bp.NameEn,
					DescriptionEn = bp.DescriptionEn
				}).ToList()
				})
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
				.AsNoTracking()
				.OrderByDescending(bp => bp.Date)
				.Take(4)
				.Select(bp => new BlogPostSummary
				{
					Id = bp.Id,
					Name = bp.Name,
					Description = bp.Description,
					FilePath = bp.ImagePath,
					Slug = bp.Slug,
					TimePublic = bp.Date,
					NameEn = bp.NameEn,
					DescriptionEn = bp.DescriptionEn
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
				.AsNoTracking()
				.Select(bp => new BlogPostSummary
				{
					Id = bp.Id,
					Name = bp.Name,
					Description = bp.Description,
					FilePath = bp.ImagePath,
					Slug = bp.Slug,
					TimePublic = bp.Date,
					NameEn = bp.NameEn,
					DescriptionEn = bp.DescriptionEn
				})

				.ToListAsync();
			return result;
		}

		/// <summary>
		/// Získá všechny blog příspěvky, které patří do kategorie projektů.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetAllProject()
		{
			var result = await context.BlogPosts
				.AsNoTracking()
				.Where(bp => bp.BlogCategory.IsProjectCategory)
				.Select(bp => new BlogPostSummary
				{
					Id = bp.Id,
					Name = bp.Name,
					Description = bp.Description,
					FilePath = bp.ImagePath,
					Slug = bp.Slug,
					TimePublic = bp.Date,
					NameEn = bp.NameEn,
					DescriptionEn = bp.DescriptionEn
				})
				.ToListAsync();
			return result;
		}

		/// <summary>
		/// Získá tři nejnovější blog příspěvky pro hlavní stránku.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetThreePost()
		{
			var result = await context.BlogPosts
				.AsNoTracking()
				.OrderByDescending(bp => bp.Date)
				.Take(3)
				.Select(bp => new BlogPostSummary
				{
					Id = bp.Id,
					Name = bp.Name,
					Description = bp.Description,
					FilePath = bp.ImagePath,
					Slug = bp.Slug,
				
					NameEn = bp.NameEn,
					DescriptionEn = bp.DescriptionEn
				})
				.ToListAsync();
			return result;
		}

		/// <summary>
		/// Získá blog příspěvek podle jeho id.
		/// </summary>
		public async Task<EditBlogPostDto?> GetBlogPostById(Guid id)
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
				FileUpload = existingBlogPost.ImagePath,
				NameEn = existingBlogPost.NameEn,
				DescriptionEn = existingBlogPost.DescriptionEn,
				ContentEn = existingBlogPost.ContentEn,
				TitleEn = existingBlogPost.TitleEn,
				KeywordsEn = existingBlogPost.KeywordsEn
			};

			return editBlogPostDto;
		}

		/// <summary>
		/// Získá list blog kategorií, které následně vykreslíme.
		/// </summary>
		public async Task<List<BlogCategoryDto>> GetAllCategoriesTask()
		{
			var blogCategory = await context.BlogCategories.AsNoTracking().ToListAsync();

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

			var sanitizer = new Ganss.Xss.HtmlSanitizer();

			existingBlogPost.Description = editBlogPostRequest.Description;
			existingBlogPost.Content = sanitizer.Sanitize(editBlogPostRequest.Content ?? "");
			existingBlogPost.Title = editBlogPostRequest.Title;
			existingBlogPost.Author = editBlogPostRequest.Author;
			existingBlogPost.Keywords = editBlogPostRequest.Keywords;
			existingBlogPost.BlogCategoryId = editBlogPostRequest.BlogCategoryId;
			existingBlogPost.Name = editBlogPostRequest.Name;
			existingBlogPost.NameEn = editBlogPostRequest.NameEn;
			existingBlogPost.DescriptionEn = editBlogPostRequest.DescriptionEn;
			existingBlogPost.ContentEn = sanitizer.Sanitize(editBlogPostRequest.ContentEn ?? "");
			existingBlogPost.TitleEn = editBlogPostRequest.TitleEn;
			existingBlogPost.KeywordsEn = editBlogPostRequest.KeywordsEn;

			if (editBlogPostRequest.FileUpload != null)
			{
				existingBlogPost.ImagePath = await imageService.UploadImageAsync(editBlogPostRequest.FileUpload, "blog");
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
			var query = context.BlogPosts.AsNoTracking().AsQueryable();

			if (!string.IsNullOrEmpty(searchString))
			{
				query = query.Where(p =>
					p.Name.Contains(searchString) ||
					p.Description.Contains(searchString));
			}

			if (!string.IsNullOrEmpty(author))
			{
				query = query.Where(p => p.Author == author);
			}

			if (!string.IsNullOrEmpty(keyword))
			{
				query = query.Where(p => p.Keywords == keyword);
			}

			if (category != Guid.Empty)
			{
				query = query.Where(p => p.BlogCategoryId == category);
			}

			if (fromDate.HasValue)
			{
				query = query.Where(p => p.Date >= fromDate.Value);
			}

			if (toDate.HasValue)
			{
				query = query.Where(p => p.Date <= toDate.Value);
			}

			return await query.Select(p => new BlogPostSummary
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				FilePath = p.ImagePath,
				Slug = p.Slug,
				TimePublic = p.Date,
				NameEn = p.NameEn,
				DescriptionEn = p.DescriptionEn
			}).ToListAsync();
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

		public async Task<List<BlogPostSummary>> SearchBlogPostsAsync(string query)
		{
			// Implementujte logiku vyhledávání, např. dotazování databáze podle klíčových slov
			var results = await context.BlogPosts
				.AsNoTracking()
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