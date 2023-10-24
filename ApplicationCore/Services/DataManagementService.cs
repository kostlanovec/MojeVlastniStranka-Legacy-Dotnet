using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class DataManagementService
	{
		// Připojení k databázi pomocí depedency injection.
		private readonly DataContext context;

		public DataManagementService(DataContext context)
		{
			this.context = context;
		}

		//to-do vyřešit problém s tím, že když to mám v debug režimu, tak to po mně chce, abych tam dával růčně Id (přežížení)
		public async Task AddContactForm(ContactFormularRequest contactFormularRequest)
		{
			var contactFormular = ContactForm.Create(
				699,
				contactFormularRequest.FirstName,
				contactFormularRequest.LastName,
				contactFormularRequest.Email,
				contactFormularRequest.PhoneNumber,
				contactFormularRequest.Message,
				contactFormularRequest.DateSend = DateTime.Now
			);

			context.ContactForms.Add(contactFormular);
			await context.SaveChangesAsync();
		}

		/// <summary>
		/// Nová metoda pro získání všech kontaktních formulářů.
		/// </summary>
		public async Task<List<ContactForm>> GetAllContactForms()
		{
			return await context.ContactForms.ToListAsync();
		}

		/// <summary>
		/// Získá všechny blog kategorie.
		/// </summary>
		public async Task<List<BlogCategory>> GetAllBlogCategory()
		{
			return await context.BlogCategories.ToListAsync();
		}

		/// <summary>
		/// Získá všechny blog příspěvky..
		/// </summary>
		public async Task<List<BlogPost>> GetAllBlogPosts()
		{
			return await context.BlogPosts.ToListAsync();
		}

		/// <summary>
		/// Získá všechny popisky k blog příspěvku.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetAllBlogPostSummaries()
		{
			return await context.BlogPosts
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
		}

		/// <summary>
		/// Uloží obrázek do určeného úložiště.
		/// </summary>
		private async Task<string> UploadImageAsync(IFormFile file)
		{
			// to-do vyřešit tento otřesný hard-coding
			var uploadsDirectory = "C:\\app\\MojeVlastniStrankaFinanali\\Web\\wwwroot\\images\\blog";
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


		/// <summary>
		/// Přidá nový blog příspěvek.
		/// </summary>
		public async Task AddBlogPost(BlogPostRequest blogPostRequest)
		{
			var imagePath = await UploadImageAsync(blogPostRequest.FileUpload); // Získání cesty k uloženému obrázku
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
				blogPostRequest.DatePublic = DateTime.Now
			);

			context.BlogPosts.Add(blogPost);
			await context.SaveChangesAsync();
		}

		/// <summary>
		/// Získá blog příspěvek podle jeho id.
		/// </summary>
		public async Task<EditBlogPostDto> GetBlogPostById(int id)
		{
			var existingBlogPost = await context.BlogPosts
				.SingleOrDefaultAsync(bp => bp.Id == id);

			if (existingBlogPost == null)
			{
				// Handle the case where the blog post with the specified id was not found.
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
		/// Aktualizuje již existující blog příspěvek.
		/// </summary>
		public async Task UpdateBlogPost(EditBlogPostRequest editBlogPostRequest)
		{
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
		}

		// to-do přidat funkcionalitu na smazání blog příspěvku
		public async Task DeleteBlogPost(int BlogId)
		{
			var existingBlog = await context.BlogPosts.SingleOrDefaultAsync(bp => bp.Id == BlogId);
			if (existingBlog != null)
			{
				context.Remove(existingBlog);
			}

			await context.SaveChangesAsync();
		}

		/// <summary>
		/// Získá tři blog příspěvky.
		/// </summary>
		public async Task<List<BlogPostSummary>> GetThreePost()
		{
			return await context.BlogPosts
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
		}

		/// <summary>
		/// Přidá novou blog kategorii.
		/// </summary>
		public async Task AddBlogCategory(string CategoryNameAdd)
		{
			var bloCategoryExist = await context.BlogCategories.SingleOrDefaultAsync(bp => bp.Name == CategoryNameAdd);
			// to-do Validace kategorie, zda existuje nebo ne
			// to-do Můžeme provést další validaci

			if (bloCategoryExist != null)
			{
				var newCategory = BlogCategory.Create(null, CategoryNameAdd);
				context.BlogCategories.Add(newCategory);
				await context.SaveChangesAsync();
			}

		}

		/// <summary>
		/// Odstraní již existující blog příspěvek podle jeho Id.
		/// </summary>
		public async Task DeleteBlogCategory(int BlogCategoryId)
		{
			var existingBlogCategory = await context.BlogCategories.SingleOrDefaultAsync(bp => bp.Id == BlogCategoryId);
			if (existingBlogCategory != null)
			{
				context.Remove(existingBlogCategory);
			}

			await context.SaveChangesAsync();
		}
	}
}
