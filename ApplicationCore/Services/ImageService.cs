using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	internal class ImageService
	{
		private readonly IHostEnvironment environment;
		private readonly DataContext context;

		public ImageService(DataContext context, IHostEnvironment environment)
		{
			this.environment = environment;
			this.context = context;
		}

		/// <summary>
		/// Uploudování obrázků do wwwrootu.
		/// </summary>
		public async Task UploadImageAsync(AddImageRequest addImageRequest)
		{
			var currentDirectory = Directory.GetCurrentDirectory();

			var modifiedPath = Path.Combine(currentDirectory, "Web", "wwwroot");
			var uploadsDirectory = modifiedPath + "\\images\\blog";
			var filePath = Path.Combine(uploadsDirectory, addImageRequest.FileUpload.Name);

			if (!Directory.Exists(uploadsDirectory))
			{
				Directory.CreateDirectory(uploadsDirectory);
			}

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await addImageRequest.FileUpload.CopyToAsync(fileStream);
			}

			var image = Image.Create(Path.Combine(addImageRequest.FileUpload.FileName), addImageRequest.Description);
			this.context.Images.Add(image);
			await this.context.SaveChangesAsync();
		}

		/// <summary>
		/// Získání všech obrázku.
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
		/// Vymazání obrázku.
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