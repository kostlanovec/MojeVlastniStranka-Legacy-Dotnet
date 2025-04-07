using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class ImageService
	{
		private readonly DataContext context;

		public ImageService(DataContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Uloží obrázek do zadané podsložky (např. "blog", "profile", "general").
		/// </summary>
		public async Task<string> UploadImageAsync(IFormFile file, string subfolder = "general")
		{
			if (file == null || file.Length == 0)
				throw new ArgumentException("No file uploaded.");

			var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
			var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

			if (!allowedExtensions.Contains(extension))
				throw new InvalidOperationException("Unsupported file type.");

			var uploadsRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
			var uploadsDirectory = Path.Combine(uploadsRoot, subfolder);

			if (!Directory.Exists(uploadsDirectory))
				Directory.CreateDirectory(uploadsDirectory);

			var uniqueFileName = $"{Guid.NewGuid()}{extension}";
			var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			// Vrací cestu použitelnou jako <img src="...">
			return $"/images/{subfolder}/{uniqueFileName}";
		}

		/// <summary>
		/// Získání všech obrázků.
		/// </summary>
		public async Task<List<ImageDto>> GetImagesAsync()
		{
			return await this.context.Images
				.Select(image => new ImageDto
				{
					Id = image.Id,
					FileName = image.FileName,
					Description = image.Description
				})
				.ToListAsync();
		}

		/// <summary>
		/// Aktualizování popisku obrázku.
		/// </summary>
		public async Task UpdateImageDescriptionAsync(int imageId, string newDescription)
		{
			var image = await this.context.Images.FindAsync(imageId);
			if (image != null)
			{
				image.Description = newDescription;
				await this.context.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Vymazání obrázku (pouze z databáze – můžeš doplnit i mazání fyzického souboru).
		/// </summary>
		public async Task DeleteImageAsync(int imageId)
		{
			var image = await this.context.Images.FindAsync(imageId);
			if (image != null)
			{
				this.context.Images.Remove(image);
				await this.context.SaveChangesAsync();
			}
		}
	}
}
