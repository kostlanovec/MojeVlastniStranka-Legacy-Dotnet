using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting; // IWebHostEnvironment
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class ImageService
	{
		private readonly DataContext context;
		private readonly string webRootPath;

		public ImageService(DataContext context, IWebHostEnvironment env)
		{
			this.context = context;
			this.webRootPath = env.WebRootPath; // typicky /app/wwwroot v dockeru
		}

		public async Task<string> UploadImageAsync(IFormFile file, string subfolder)
		{
			if (file == null || file.Length == 0)
				throw new ArgumentException("No file uploaded.");

			var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
			var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
			if (!allowed.Contains(ext))
				throw new InvalidOperationException("Unsupported file type.");

			var uploadsRoot = Path.Combine(webRootPath, "user-uploads", subfolder ?? string.Empty);
			Directory.CreateDirectory(uploadsRoot);

			var fileName = $"{Guid.NewGuid()}{ext}";
			var filePath = Path.Combine(uploadsRoot, fileName);

			using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 64 * 1024, useAsync: true);
			await file.CopyToAsync(stream);

			// veřejná URL pro <img src="...">
			return $"/user-uploads/{subfolder}/{fileName}";
		}

		public async Task<List<ImageDto>> GetImagesAsync()
		{
			return await context.Images
				.Select(i => new ImageDto { Id = i.Id, FileName = i.FileName, Description = i.Description })
				.ToListAsync();
		}

		public async Task UpdateImageDescriptionAsync(int imageId, string newDescription)
		{
			var image = await context.Images.FindAsync(imageId);
			if (image is null) return;
			image.Description = newDescription;
			await context.SaveChangesAsync();
		}

		public async Task DeleteImageAsync(int imageId)
		{
			var image = await context.Images.FindAsync(imageId);
			if (image is null) return;
			context.Images.Remove(image);
			await context.SaveChangesAsync();
		}
	}
}
