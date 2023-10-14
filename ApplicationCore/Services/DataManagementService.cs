using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
    public class DataManagementService
	{
		// Připojení k databázi.
		private readonly DataContext context;

		public DataManagementService(DataContext context)
		{
			this.context = context;
		}

        //to-do vyřešit problém s tím, že když to mám v debug režimu, tak to po mně chce, abych tam dával růčně Id
        public async Task AddContactForm(ContactFormularRequest contactFormularRequest)
        {
            var contactFormular = ContactForm.Create(
				1,
				contactFormularRequest.FirstName,
                contactFormularRequest.LastName,
                contactFormularRequest.Email,
                contactFormularRequest.PhoneNumber,
                contactFormularRequest.Message,
				contactFormularRequest.date = DateTime.Now
            );

            context.ContactForms.Add(contactFormular);
            await context.SaveChangesAsync();
        }

        // Nová metoda pro získání všech kontaktních formulářů.
        public async Task<List<ContactForm>> GetAllContactForms()
        {
	        return await context.ContactForms.ToListAsync();
        }

        public async Task<List<BlogCategory>> GetAllBlogCategory()
        {
	        return await context.BlogCategories.ToListAsync();
        }

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
				})
				.ToListAsync();
		}

		public async Task<string> UploadImageAsync(IFormFile file)
		{
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
				blogPostRequest.date = DateTime.Now
			);
            
            context.BlogPosts.Add( blogPost );
            await context.SaveChangesAsync();
        }

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
				blogCategory = existingBlogPost.blogCategory
			};

			// Use the HandleFileUpload method to set the FileUpload property
			editBlogPostDto.HandleFileUpload(existingBlogPost.ImagePath);

			return editBlogPostDto;
		}


		public async Task UpdateBlogPost(EditBlogPostRequest editBlogPostRequest)
		{

			var existingBlogPost = await context.BlogPosts.SingleOrDefaultAsync(bp => bp.Id == editBlogPostRequest.Id);

			if (existingBlogPost != null)
			{
				// Aktualizujte hodnoty příspěvku na základě nových dat z updatedBlogPost.
				existingBlogPost.Description = editBlogPostRequest.Description;
				existingBlogPost.Content = editBlogPostRequest.Content;
				existingBlogPost.Title = editBlogPostRequest.Title;
				existingBlogPost.Author = editBlogPostRequest.Author;
				existingBlogPost.Keywords = editBlogPostRequest.Keywords;
				existingBlogPost.BlogCategoryId = editBlogPostRequest.BlogCategoryId;
				existingBlogPost.Name = editBlogPostRequest.Name;
				existingBlogPost.ImagePath = await UploadImageAsync(editBlogPostRequest.FileUpload);

				// Pokud máte také aktualizovat obrázek, můžete zde přidat kód pro aktualizaci obrázku.

				await context.SaveChangesAsync();
			}
		}

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
	}
}
