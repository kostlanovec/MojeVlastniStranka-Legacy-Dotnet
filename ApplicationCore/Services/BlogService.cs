using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

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
		public async Task<FormProcessingResult> AddBlogPost(BlogPostRequest blogPostRequest)
		{
			var result = new FormProcessingResult();
			var validationResults = blogPostRequest.Validate(new ValidationContext(blogPostRequest)).ToList();

            string imagePath = "images/default.jpg";
			if (validationResults.Any())
			{
				result.IsSuccess = false;
				result.Errors = validationResults;
				return result;
			}

            if (blogPostRequest.FileUpload != null)
            {
                imagePath = await UploadImageAsync(blogPostRequest.FileUpload);
            }
			var blogPost = BlogPost.Create(
				Guid.NewGuid(),
				blogPostRequest.Description,
				blogPostRequest.Content,
				blogPostRequest.Title,
				blogPostRequest.Author,
				blogPostRequest.Keywords,
				blogPostRequest.BlogCategoryId,
				blogPostRequest.Name,
				imagePath,
				blogPostRequest.Slug,
				blogPostRequest.DatePublic =  DateTime.Now
			);

			context.BlogPosts.Add(blogPost);
			await context.SaveChangesAsync();
			result.IsSuccess = true;
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
				blogCategory = existingBlogPost.blogCategory,
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

		/// <summary>
		/// Aktualizuje blog příspěvky.
		/// </summary>
		public async Task<FormProcessingResult> UpdateBlogPost(EditBlogPostRequest editBlogPostRequest)
		{
			var result = new FormProcessingResult();
			var existingBlogPost = await context.BlogPosts.SingleOrDefaultAsync(bp => bp.Id == editBlogPostRequest.Id);

			if (existingBlogPost != null)
			{
				if (editBlogPostRequest != null)
				{
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
				}

				await context.SaveChangesAsync();
			}
			return result;
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
		public async Task<FormProcessingResult> AddBlogCategory(string CategoryNameAdd)
		{
			var formProcessingResult = new FormProcessingResult();
			var blogCategoryExist = await context.BlogCategories.SingleOrDefaultAsync(bp => bp.Name == CategoryNameAdd);
			// todo Validace kategorie, zda existuje nebo ne
			// todo Můžeme provést další validaci

			if (blogCategoryExist == null)
			{
				var newCategory = BlogCategory.Create(Guid.NewGuid(), CategoryNameAdd);
				context.BlogCategories.Add(newCategory);
				await context.SaveChangesAsync();
			}
			return formProcessingResult;

		}

		/// <summary>
		/// Smazání blog kategorie podle jeho id.
		/// </summary>
		/// <param name="BlogCategoryId">Smazání blog kategorie.</param>
		public async Task<FormProcessingResult> DeleteBlogCategory(Guid BlogCategoryId)
        {
			var formProcessingResult = new FormProcessingResult();
			var existingBlogCategory = await context.BlogCategories.SingleOrDefaultAsync(bp => bp.Id == BlogCategoryId);
			// Blog 1 je takzvaně neučitý
				var existingAllBlogWithDeleteBlogCategory = context.BlogPosts.Where(bp => bp.BlogCategoryId == BlogCategoryId);

				if (existingAllBlogWithDeleteBlogCategory.Any())
				{
					foreach (var blogPost in existingAllBlogWithDeleteBlogCategory)
					{
						blogPost.BlogCategoryId = Guid.Empty;
					}
				}

				context.Remove(existingBlogCategory);
				await context.SaveChangesAsync();
			return formProcessingResult;
		}

		/// <summary>
		/// Smaže blog příspěvek podle jeho Id.
		/// </summary>
		public async Task<FormProcessingResult> DeleteBlogPost(Guid BlogId)
		{
			var formProcessingResult = new FormProcessingResult();
			var existingBlog = await context.BlogPosts.SingleOrDefaultAsync(bp => bp.Id == BlogId);
			if (existingBlog != null)
			{
				context.Remove(existingBlog);
				await context.SaveChangesAsync(); ;
			}
			return formProcessingResult;
		}

		/// <summary>
		/// Uloží obrázek do určeného úložiště.
		/// </summary>
		private async Task<string> UploadImageAsync(IFormFile file)
		{
            var currentDirectory = Directory.GetCurrentDirectory();
            var modifiedPath = Path.Combine(currentDirectory.Substring(0, currentDirectory.LastIndexOf("Admin")), "Web", "wwwroot");

            var uploadsDirectory = modifiedPath + "\\images\\blog";
			var filePath = Path.Combine(uploadsDirectory, file.FileName);

			if (!Directory.Exists(uploadsDirectory))

			{
				Directory.CreateDirectory(uploadsDirectory);
			}

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return ("images/blog/" + file.FileName);
		}

	}
	 }